using System.IO;
using System; // Asegúrate de incluir este namespace
using UnityEngine;
//using iTextSharp.text;
//using iTextSharp.text.pdf;

public class PrintingManager : MonoBehaviour
{
   /* public string filePath = "Ticket.pdf";
    public SaveLoadManager saveLoadManager;
    public Emailer sendMail;
    private void Awake()
    {
        // Obtener la referencia de SaveLoadManager
        saveLoadManager = GetComponent<SaveLoadManager>();
        if (saveLoadManager == null)
        {
            Debug.LogError("No se encontró el script SaveLoadManager en la escena.");
        }
    }

    void Start()
    {
        // Define el path del archivo PDF
        string path = Path.Combine(Application.dataPath, filePath);
        Debug.Log("Ruta del archivo PDF: " + path);

        if (saveLoadManager == null)
        {
            Debug.LogError("No se encontró el script SaveLoadManager en la escena.");
            return;
        }

        PlayerData[] loadedData = saveLoadManager.LoadData();

        if (loadedData == null)
        {
            Debug.LogWarning("No se encontraron datos para generar el archivo PDF.");
            return;
        }

        if (loadedData.Length == 0)
        {
            Debug.LogWarning("El array de datos cargados está vacío.");
        }
        else
        {
            foreach (var data in loadedData)
            {
                if (data == null)
                {
                    Debug.LogError("Un elemento en loadedData es null.");
                }
                else
                {
                    Debug.Log($"Datos cargados: {data.playerName}, {data.mail}, Tono de pelo: {data.pelo}, Tono de piel: {data.piel}, Respuestas: {string.Join(",", data.respuestas)}, Tiempo: {string.Join(",", data.respuestasTiempo)}, Ambigrama: {data.nombreAmbigrama}, Tiempo ambigrama: {data.tiempoDeAmbigrama}");
                }
            }
        }

        GenerateFile(path, loadedData);
    }

    public void GenerateFile(string path, PlayerData[] data)
    {
        // Asegúrate de que el archivo no exista antes de intentar eliminarlo
        if (File.Exists(path))
        {
            try
            {
                File.Delete(path);
            }
            catch (IOException ex)
            {
                Debug.LogError($"Error al eliminar el archivo existente: {ex.Message}");
                return;
            }
        }

        // Crear y configurar el documento PDF
        using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            using (var document = new Document(PageSize.A4, 10f, 10f, 10f, 0f))
            {
                PdfWriter.GetInstance(document, fileStream);

                document.Open();

                BaseFont baseFont = null;
                try
                {
                    baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                }
                catch (Exception ex)
                {
                    Debug.LogError("Error al cargar la fuente Helvética: " + ex.Message);
                    // Cargar una fuente alternativa
                    baseFont = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                }

                if (baseFont == null)
                {
                    Debug.LogError("No se pudo cargar ninguna fuente.");
                    return;
                }

                var font = new iTextSharp.text.Font(baseFont, 12);

                // Agregar título
                Paragraph title = new Paragraph("RISK MANAGEMENT", font);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph("\n")); // Añadir espacio después del título

                // Agregar datos de PlayerData
                if (data != null && data.Length > 0)
                {
                    foreach (var playerData in data)
                    {
                        if (playerData == null)
                        {
                            Debug.LogError("playerData es null.");
                            continue;
                        }

                        document.Add(new Paragraph($"Nombre: {playerData.playerName}", font));
                        document.Add(new Paragraph($"Mail: {playerData.mail}", font));
                        document.Add(new Paragraph($"Tono de pelo: {playerData.pelo}", font));
                        document.Add(new Paragraph($"Tono de piel: {playerData.piel}", font));
                        document.Add(new Paragraph($"Respuestas elegidas: {string.Join(",", playerData.respuestas)}", font));
                        document.Add(new Paragraph($"Tiempo de respuestas: {string.Join(",", playerData.respuestasTiempo)}", font));
                        document.Add(new Paragraph($"Ambigrama elegido: {playerData.nombreAmbigrama}", font));
                        document.Add(new Paragraph($"Tiempo ambigrama: {playerData.tiempoDeAmbigrama}", font));
                        document.Add(new Paragraph("\n----------------------------\n", font));
                    }
                }
                else
                {
                    document.Add(new Paragraph("No se encontraron datos de jugadores.", font));
                }

                document.Close(); // Cierra el documento aquí
            }
        }

        PrintFiles(path);
        sendMail.send();
    }

    void PrintFiles(string path)
    {
        if (File.Exists(path))
        {
            Debug.Log("Archivo PDF generado correctamente en: " + path);

            // Abre el archivo PDF generado
            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error al abrir el archivo PDF: {ex.Message}");
            }
        }
        else
        {
            Debug.LogError("El archivo PDF no se generó correctamente.");
        }
    }*/
}
