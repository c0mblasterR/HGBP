using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Security.Cryptography;
using System.Text;
using System.Collections;

public class HGBPController : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_InputField passwordInputField;
    public TMP_Text resultText;

    private const string hibpApiUrl = "https://api.pwnedpasswords.com/range/";

    public void CheckPassword()
    {
        string password = passwordInputField.text;
        if (string.IsNullOrEmpty(password))
        {
            resultText.text = "Please enter a password.";
            return;
        }

        StartCoroutine(CheckHIBP(password));
    }

    private IEnumerator CheckHIBP(string password)
    {
        string sha1 = HashPassword(password).ToUpper();
        string prefix = sha1.Substring(0, 5);
        string suffix = sha1.Substring(5);

        UnityWebRequest request = UnityWebRequest.Get(hibpApiUrl + prefix);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            resultText.text = $"Error: {request.error}";
            yield break;
        }

        string[] lines = request.downloadHandler.text.Split('\n');
        bool found = false;

        foreach (string line in lines)
        {
            string[] parts = line.Split(':');
            if (parts.Length == 2 && parts[0].Trim() == suffix)
            {
                found = true;
                resultText.text = $"⚠️ This password has been seen {parts[1].Trim()} times in data breaches.";
                break;
            }
        }

        if (!found)
        {
            resultText.text = "✅ This password was NOT found in known data breaches.";
        }
    }

    private string HashPassword(string input)
    {
        using (SHA1 sha1 = SHA1.Create())
        {
            byte[] bytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
                builder.Append(b.ToString("x2"));
            return builder.ToString();
        }
    }
}
