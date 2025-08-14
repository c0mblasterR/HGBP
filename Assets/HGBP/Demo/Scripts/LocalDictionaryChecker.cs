using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class LocalDictionaryChecker : MonoBehaviour
{
    [Header("Dictionary Settings")]
    [Tooltip("Kontrol edilecek dictionary dosyas�n�n tam yolu (Assets/../ �eklinde)")]
    public string dictionaryFilePath;

    public enum DictionaryFormat { JSON, TXT }
    [Tooltip("Dictionary dosya format�")]
    public DictionaryFormat dictionaryFormat = DictionaryFormat.JSON;

    [Header("UI References")]
    public TMP_InputField inputField;
    public TMP_Text resultText;

    private HashSet<string> passwordSet = new HashSet<string>();

    private void Start()
    {
        LoadDictionary();
    }

    private void LoadDictionary()
    {
        if (string.IsNullOrEmpty(dictionaryFilePath))
        {
            Debug.LogError("Dictionary file path is empty!");
            return;
        }

        if (!File.Exists(dictionaryFilePath))
        {
            Debug.LogError($"Dictionary file not found: {dictionaryFilePath}");
            return;
        }

        passwordSet.Clear();

        try
        {
            switch (dictionaryFormat)
            {
                case DictionaryFormat.JSON:
                    string jsonText = File.ReadAllText(dictionaryFilePath);
                    DictionaryWrapper wrapper = JsonUtility.FromJson<DictionaryWrapper>(jsonText);
                    if (wrapper?.passwords != null)
                    {
                        foreach (var pass in wrapper.passwords)
                        {
                            passwordSet.Add(pass);
                        }
                    }
                    else
                    {
                        Debug.LogError("JSON dosyas�ndan parola listesi okunamad�.");
                    }
                    break;

                case DictionaryFormat.TXT:
                    string[] lines = File.ReadAllLines(dictionaryFilePath);
                    foreach (var line in lines)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                            passwordSet.Add(line.Trim());
                    }
                    break;
            }
            Debug.Log($"Dictionary loaded with {passwordSet.Count} entries.");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Dictionary loading failed: {e.Message}");
        }
    }

    public void CheckPassword()
    {
        if (inputField == null || resultText == null)
        {
            Debug.LogError("UI references are not assigned.");
            return;
        }

        string password = inputField.text;
        if (string.IsNullOrEmpty(password))
        {
            resultText.text = "L�tfen bir �ifre girin.";
            return;
        }

        if (passwordSet.Contains(password))
        {
            resultText.text = "�ifre zay�f veya daha �nce kullan�lm��!";
        }
        else
        {
            resultText.text = "�ifre g��l� g�r�n�yor.";
        }
    }
}
