using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;

namespace UXF
{
    public class simpleHTTPPost : MonoBehaviour
    {
        [Tooltip("URL of the form to POST to.")]
        public string url = "http://127.0.0.1:5000/";

        [Tooltip("Enable to use username and password to add Basic HTTP Authentication to the request.")]
        public bool httpBasicAuthentication = true;
        [BasteRainGames.HideIf("httpBasicAuthentication", false)]
        public string username = "susan";
        [BasteRainGames.HideIf("httpBasicAuthentication", false)]
        public string password = "password";
        public Session session;

        void Start()
        {
            SendToSheets();
        }

        void SendToSheets()
{
    WWWForm form = new WWWForm();

    // Create a dictionary
    Dictionary<string, string> data = new Dictionary<string, string>
    {
        {"phrase1", "I have"},
        {"number", "24"},
        {"phrase2", "oranges"}
    };

    // Add each item in the dictionary to the form
    foreach (var item in data)
    {
        form.AddField(item.Key, item.Value);
    }

    UnityWebRequest www = UnityWebRequest.Post(url, form);

    if (httpBasicAuthentication)
    {
        string auth = username + ":" + password;
        auth = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
        auth = "Basic " + auth;
        www.SetRequestHeader("AUTHORIZATION", auth);
    }

    StartCoroutine(SendRequest(www));
}

        IEnumerator SendRequest(UnityWebRequest www)
        {
            yield return www.SendWebRequest();

            bool error;
#if UNITY_2020_OR_NEWER
            error = www.result != UnityWebRequest.Result.Success;
#else
#pragma warning disable
            error = www.isHttpError || www.isNetworkError;
#pragma warning restore
#endif
            if (error)
            {
                Debug.LogError(www.error);
            }
        }
    }
}