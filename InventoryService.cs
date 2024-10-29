using System.Collections.Generic;
using UnityEngine;

namespace Friction
{
    public static class InventoryService
    {
        public static void GetUserInventory(System.Action<string> onSuccess = null, System.Action<string> onError = null)
        {
            if (!FrictionSDK.IsAuthenticated()) { onError?.Invoke("User not authenticated."); return; }

            string url = $"{FrictionSDK.BaseURL}/User/Inventory";
            FrictionSDKHelpers.PostRequest(url, new Dictionary<string, object>(), onSuccess, onError, FrictionSDK.GetSessionToken());
        }
    }
}
