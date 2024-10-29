using System.Collections.Generic;
using UnityEngine;
using Friction;
namespace Friction
{
    public static class AuthService
    {
        public static void Login(string authenticationId, List<string> tags = null, System.Action<string> onSuccess = null, System.Action<string> onError = null)
        {
            string url = $"{FrictionSDK.BaseURL}/login";
            var data = new Dictionary<string, object> {
                { "AuthenticationId", authenticationId },
                { "Tags", tags }
            };

            FrictionSDKHelpers.PostRequest(url, data, (response) => {
                Debug.Log("Login successful: " + response);
                string token = ExtractSessionToken(response);
                FrictionSDK.SetSessionToken(token);
                onSuccess?.Invoke(response);
            }, onError);
        }

        private static string ExtractSessionToken(string jsonResponse)
        {
            return jsonResponse;
        }
    }
}
