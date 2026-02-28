using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileSaver : MonoBehaviour
{
    public void SavePdfToPublicDownloads()
    {
        string fileName = "Ticket.pdf";
        string pdfData = "Aquí irían los datos del PDF en formato byte[]";

        string downloadPath = GetPublicDownloadsPath();

        try
        {
            File.WriteAllBytes(downloadPath, System.Text.Encoding.UTF8.GetBytes(pdfData));
            Debug.Log("Archivo guardado en: " + downloadPath);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al guardar el archivo: " + ex.Message);
        }
    }

    private string GetPublicDownloadsPath()
    {
        string path = Path.Combine(Application.persistentDataPath, "..", "Download", "Ticket.pdf");
        return path;
    }
}
