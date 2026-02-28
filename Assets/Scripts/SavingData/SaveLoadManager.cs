using System.IO;
using System;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    private string filePath;

    void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "Data.txt");
        Debug.Log(filePath);

        // Ejemplo de uso
        PlayerData data = new PlayerData
        {
            playerName = QuestionsController.Instance.nombre,
            mail = QuestionsController.Instance.mail,
            genero = QuestionsController.Instance.genero,
            pelo = QuestionsController.Instance.colorPelo,
            piel = QuestionsController.Instance.colorPiel,
            respuestas = QuestionsController.Instance.respuestas,
            respuestasTiempo = QuestionsController.Instance.respuestasTiempo,
            nombreAmbigrama = QuestionsController.Instance.nombreAmbigrama,
            tiempoDeAmbigrama = QuestionsController.Instance.tiempoDeAmbigrama
        };

        SaveData(data);
    }

    public void SaveData(PlayerData data)
    {
        string respuestasString = string.Join(",", data.respuestas);
        string respuestasTiempoString = string.Join(",", data.respuestasTiempo);

        string dataToSave = $"● Nombre: {data.playerName}\n" +
                            $"● Mail: {data.mail}\n" +
                            $"● Género: {data.genero}\n" +
                            $"● Tono de pelo: {data.pelo}\n" +
                            $"● Tono de piel: {data.piel}\n" +
                            $"● Respuestas elegidas: {respuestasString}\n" +
                            $"● Tiempo de respuestas: {respuestasTiempoString}\n" +
                            $"● Ambigrama elegido: {data.nombreAmbigrama}\n" +
                            $"● Tiempo ambigrama: {data.tiempoDeAmbigrama}\n" +
                            "----------------------------";

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(dataToSave.TrimEnd());
        }

        Debug.Log("Datos guardados en: " + filePath);
    }

    public PlayerData[] LoadData()
    {
        if (File.Exists(filePath))
        {
            string[] allDataLines = File.ReadAllLines(filePath);

            // Verificar el número de líneas en el archivo
            Debug.Log($"Número de líneas en el archivo: {allDataLines.Length}");
            if (allDataLines.Length % 9 != 0) // Se espera un conjunto de 8 líneas de datos + 1 línea separadora
            {
                Debug.LogError("El archivo de datos tiene un número incorrecto de líneas.");
                return null;
            }

            int numberOfRecords = allDataLines.Length / 9;
            PlayerData[] allData = new PlayerData[numberOfRecords];

            for (int i = 0; i < numberOfRecords; i++)
            {
                int index = i * 9;

                // Mostrar las líneas leídas para depuración
                Debug.Log($"Leyendo líneas {index} a {index + 8}:");
                for (int j = 0; j < 9; j++)
                {
                    Debug.Log(allDataLines[index + j]);
                }

                // Validar las líneas antes de hacer Substring
                string playerNameLine = allDataLines[index];
                string mailLine = allDataLines[index + 1];
                string tonoPeloLine = allDataLines[index + 2];
                string tonoPielLine = allDataLines[index + 3];
                string respuestasLine = allDataLines[index + 4];
                string respuestasTiempoLine = allDataLines[index + 5];
                string nombreAmbigramaLine = allDataLines[index + 6];
                string tiempoAmbigramaLine = allDataLines[index + 7];
                string separatorLine = allDataLines[index + 8];

                if (!separatorLine.Equals("----------------------------"))
                {
                    Debug.LogError($"Línea separadora incorrecta en la línea {index + 8}");
                    return null;
                }

                if (!playerNameLine.StartsWith("nombre:") ||
                    !mailLine.StartsWith("mail:") ||
                    !tonoPeloLine.StartsWith("Tono de pelo:") ||
                    !tonoPielLine.StartsWith("Tono de piel:") ||
                    !respuestasLine.StartsWith("Respuestas elegidas:") ||
                    !respuestasTiempoLine.StartsWith("Tiempo de respuestas:") ||
                    !nombreAmbigramaLine.StartsWith("Ambigrama elegido:") ||
                    !tiempoAmbigramaLine.StartsWith("Tiempo ambigrama:"))
                {
                    Debug.LogError($"Formato de datos incorrecto en el archivo en las líneas {index} a {index + 8}");
                    return null;
                }

                try
                {
                    string[] respuestasArray = respuestasLine.Substring("Respuestas elegidas:".Length).Split(',');
                    string[] respuestasTiempoArray = respuestasTiempoLine.Substring("Tiempo de respuestas:".Length).Split(',');

                    allData[i] = new PlayerData
                    {
                        playerName = playerNameLine.Substring("nombre:".Length).Trim(),
                        mail = mailLine.Substring("mail:".Length).Trim(),
                        pelo = int.Parse(tonoPeloLine.Substring("Tono de pelo:".Length).Trim()),
                        piel = int.Parse(tonoPielLine.Substring("Tono de piel:".Length).Trim()),
                        respuestas = Array.ConvertAll(respuestasArray, s => int.Parse(s.Trim())),
                        respuestasTiempo = Array.ConvertAll(respuestasTiempoArray, s => int.Parse(s.Trim())),
                        nombreAmbigrama = nombreAmbigramaLine.Substring("Ambigrama elegido:".Length).Trim(),
                        tiempoDeAmbigrama = int.Parse(tiempoAmbigramaLine.Substring("Tiempo ambigrama:".Length).Trim())
                    };
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Error al procesar los datos en el archivo en las líneas {index} a {index + 8}: {ex.Message}");
                    return null;
                }

                Debug.Log($"Cargado: {allData[i].playerName}, {allData[i].mail}, {string.Join(",", allData[i].respuestas)}, {string.Join(",", allData[i].respuestasTiempo)}, {allData[i].nombreAmbigrama}, {allData[i].tiempoDeAmbigrama}");
            }

            Debug.Log("Datos cargados desde: " + filePath);
            return allData;
        }
        else
        {
            Debug.LogWarning("No se encontró el archivo de datos en: " + filePath);
            return null;
        }
    }

}
