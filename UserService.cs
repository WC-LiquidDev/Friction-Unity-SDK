using System.Collections.Generic;
using UnityEngine;

namespace Friction
{
    public static class UserService
    {
        public static void GetAccountInformation(System.Action<string> onSuccess = null, System.Action<string> onError = null)
        {
            if (!FrictionSDK.IsAuthenticated()) { onError?.Invoke("User not authenticated."); return; }

            string url = $"{FrictionSDK.BaseURL}/User/GetAccountInformation";
            FrictionSDKHelpers.PostRequest(url, new Dictionary<string, object>(), onSuccess, onError, FrictionSDK.GetSessionToken());
        }

        public static void UpdateUserData(Dictionary<string, object> updates, System.Action<string> onSuccess = null, System.Action<string> onError = null)
        {
            if (!FrictionSDK.IsAuthenticated()) { onError?.Invoke("User not authenticated."); return; }

            string url = $"{FrictionSDK.BaseURL}/User/UpdateUserData";
            FrictionSDKHelpers.PostRequest(url, updates, onSuccess, onError, FrictionSDK.GetSessionToken());
        }
    }
}
