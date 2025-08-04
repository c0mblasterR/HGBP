using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

namespace HGBP
{
    public class EmailChecker : MonoBehaviour
    {
        [Header("UI Elements")]
        public TMP_InputField emailInputField;
        public TMP_Text resultText;

        [Header("HIBP API Settings")]
        [Tooltip("Premium HIBP API Key required to check breached accounts")]
        public string hibpApiKey;

        private const string hibpApiUrl = "https://haveibeenpwned.com/api/v3/breachedaccount/";

        public void CheckEmail()
        {
            string email = emailInputField.text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                resultText.text = "Please enter a valid email.";
                return;
            }

            if (string.IsNullOrEmpty(hibpApiKey))
            {
                resultText.text = "API key missing. Email check is disabled.";
                return;
            }

            StartCoroutine(CheckEmailCoroutine(email));
        }

        private IEnumerator CheckEmailCoroutine(string email)
        {
            string url = hibpApiUrl + UnityWebRequest.EscapeURL(email) + "?truncateResponse=true";

            UnityWebRequest request = UnityWebRequest.Get(url);
            request.SetRequestHeader("hibp-api-key", hibpApiKey);
            request.SetRequestHeader("User-Agent", "HGBPUnityAsset");

            yield return request.SendWebRequest();

#if UNITY_2020_1_OR_NEWER
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
#else
            if (request.isNetworkError || request.isHttpError)
#endif
            {
                if (request.responseCode == 404)
                {
                    resultText.text = "Good news! This email has not been breached.";
                }
                else
                {
                    resultText.text = $"Error: {request.responseCode}\n{request.error}";
                }
            }
            else
            {
                resultText.text = "Warning: This email has been found in a breach.";
            }
        }
    }
}
