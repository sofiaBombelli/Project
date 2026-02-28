using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextFileReader : MonoBehaviour
{
    public string filePath; // Ruta al archivo TXT
    public Text displayText; // Referencia al componente de texto en el ScrollView

    void Start()
    {
      
        filePath = Path.Combine(Application.persistentDataPath, "Data.txt");
        Debug.Log(filePath);
        LoadTextFromFile();
    }

    void LoadTextFromFile()
    {
        // Asegúrate de que la ruta al archivo es correcta y que el archivo existe
        if (File.Exists(filePath))
        {
            string fileContent = File.ReadAllText(filePath); // Lee el contenido del archivo
            displayText.text = fileContent; // Muestra el contenido en el Text
        }
        else
        {
            Debug.LogError("El archivo no existe en la ruta especificada: " + filePath);
        }
    }
}
