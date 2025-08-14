using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class DictionaryWrapper
{
    public List<string> passwords;
}

public class LocalDictionaryCreator : MonoBehaviour
{
    [Header("Dictionary Settings")]
    [Tooltip("Olu�turulacak �ifre say�s�")]
    public int numberOfPasswords = 200;

    [Tooltip("��kt� dosyas�n�n kaydedilece�i klas�r yolu (Assets/../ �eklinde)")]
    public string outputFolderPath = "Assets/HGBP/Demo/GeneratedDictionaries";

    [Tooltip("Olu�turulacak dosya ad� (uzant� otomatik eklenecek)")]
    public string outputFileName = "weak_passwords";

    [Tooltip("JSON dosyas� olu�turulsun mu?")]
    public bool exportJson = true;

    [Tooltip("TXT dosyas� olu�turulsun mu?")]
    public bool exportTxt = true;

    private List<string> generatedPasswords = new List<string>();

    // Basit zay�f �ifre �retici, geli�tirilebilir
    private string GenerateWeakPassword()
    {
        // �rnek zay�f �ifreler listesi, istenirse karma��kla�t�r�labilir
        string[] weakPasswords = new string[]
        {
            "123456", "password", "123456789", "qwerty", "abc123",
            "111111", "123123", "admin", "letmein", "welcome"
        };
        return weakPasswords[Random.Range(0, weakPasswords.Length)];
    }

    public void CreateDictionary()
    {
        generatedPasswords.Clear();

        for (int i = 0; i < numberOfPasswords; i++)
        {
            generatedPasswords.Add(GenerateWeakPassword());
        }

        if (!Directory.Exists(outputFolderPath))
            Directory.CreateDirectory(outputFolderPath);

        if (exportJson)
            ExportJson();

        if (exportTxt)
            ExportTxt();

        Debug.Log($"Dictionary created with {generatedPasswords.Count} entries.");
    }

    private void ExportJson()
    {
        DictionaryWrapper wrapper = new DictionaryWrapper
        {
            passwords = generatedPasswords
        };

        string json = JsonUtility.ToJson(wrapper, true);
        string path = Path.Combine(outputFolderPath, outputFileName + ".json");

        File.WriteAllText(path, json);
        Debug.Log($"JSON dictionary saved at: {path}");
    }

    private void ExportTxt()
    {
        string path = Path.Combine(outputFolderPath, outputFileName + ".txt");
        File.WriteAllLines(path, generatedPasswords);
        Debug.Log($"TXT dictionary saved at: {path}");
    }
}
