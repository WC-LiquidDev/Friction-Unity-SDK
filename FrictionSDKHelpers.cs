using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json; 

namespace Friction
{
    public static class FrictionSDKHelpers
    {
        public static void PostRequest(string url, Dictionary<string, object> data, System.Action<string> onSuccess, System.Action<string> onError, string authHeader = null)
        {
            GameObject helperObject = new GameObject("RequestHelper");
            RequestHelper helper = helperObject.AddComponent<RequestHelper>();
            helper.SendPostRequest(url, data, onSuccess, onError, authHeader);
        }
    }

    public class RequestHelper : MonoBehaviour
    {
        public void SendPostRequest(string url, Dictionary<string, object> data, System.Action<string> onSuccess, System.Action<string> onError, string authHeader = null)
        {
            StartCoroutine(PostRequestCoroutine(url, data, onSuccess, onError, authHeader));
        }

        private IEnumerator PostRequestCoroutine(string url, Dictionary<string, object> data, System.Action<string> onSuccess, System.Action<string> onError, string authHeader)
        {
            string jsonData = JsonConvert.SerializeObject(data); 
            byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonData);

            using (UnityWebRequest www = new UnityWebRequest(url, "POST"))
            {
                www.uploadHandler = new UploadHandlerRaw(jsonBytes);
                www.downloadHandler = new DownloadHandlerBuffer();
                www.SetRequestHeader("Content-Type", "application/json");

                if (!string.IsNullOrEmpty(authHeader))
                    www.SetRequestHeader("T-Authorization", authHeader);

                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    onSuccess?.Invoke(www.downloadHandler.text);
                }
                else
                {
                    onError?.Invoke(www.error);
                }
            }
        }
    }
}
