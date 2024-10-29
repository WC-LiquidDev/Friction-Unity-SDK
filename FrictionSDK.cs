using System.Collections.Generic;
using UnityEngine;

namespace Friction
{
    public static class FrictionSDK
    {
        public static string BaseURL = "https://f9826.friction.lol/api";
        private static string sessionToken = "";
        private static string secretKey = "28c6e6b0a55a4e9bb5d3c09e6a2cf007";

        public static void Initialize(string baseUrl, string apiKey)
        {
            BaseURL = baseUrl;
            secretKey = apiKey;
            Debug.Log("Friction SDK initialized with base URL: " + BaseURL);
        }

        public static void SetSessionToken(string token)
        {
            sessionToken = token;
        }

        public static string GetSessionToken()
        {
            return sessionToken;
        }

        public static bool IsAuthenticated()
        {
            return !string.IsNullOrEmpty(sessionToken);
        }
    }
}
