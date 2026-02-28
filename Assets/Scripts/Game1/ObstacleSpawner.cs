using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Prefab del obstáculo
    public GameObject GemasPrefab;
    public Transform parent;
    public GameObject[] spawnPositions; // Array de GameObjects que definen las posiciones de spawn
    public float spawnInterval = 2.0f; // Intervalo de tiempo entre spawns
    public float fallSpeed; // Velocidad de caída de los obstáculos

    void Start()
    {
        // Iniciar la rutina de generación de obstáculos
        StartCoroutine(SpawnObstacles());
    }
   public int level;
    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            // Esperar por el intervalo de spawn
            yield return new WaitForSeconds(spawnInterval);

            // Verificar que hay posiciones de spawn definidas
            if (spawnPositions.Length == 0)
            {
                Debug.LogError("No hay posiciones de spawn definidas.");
                yield break;
            }

            // Elegir una posición de spawn aleatoria
            int randomIndex = Random.Range(0, spawnPositions.Length);
            Vector3 spawnPosition = spawnPositions[randomIndex].transform.localPosition;

            // Verificar la posición de spawn seleccionada
           // Debug.Log($"Spawnando obstáculo en la posición: {spawnPosition}");

            // Instanciar el obstáculo
            Debug.Log("SpawnPosition: " + spawnPosition);
            GameObject obstacle;

            int number = Random.Range(0, 1);
            obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
            if (number == 0) {
                
                switch (level)
                {
                    case 3:
                        obstacle.transform.localScale = Vector3.one;
                        break;
                    case 1:
                        obstacle.transform.localScale = new Vector3(2.5f, 2.5f, 0);
                        break;
                    case 2:
                        obstacle.transform.localScale = new Vector3(2, 2, 0);
                        break;
                }
            }
            else
            {
               // obstacle = Instantiate(GemasPrefab, spawnPosition, Quaternion.identity);
            }

            // Asignar el obstáculo al objeto padre
            obstacle.transform.SetParent(parent, false);

           
            // Añadir el componente de movimiento al obstáculo
            obstacle.AddComponent<ObstacleMovement>().fallSpeed = fallSpeed;

            // Verificar que el obstáculo ha sido instanciado correctamente
            if (obstacle != null)
            {
                Debug.Log($"Obstáculo instanciado en la posición: {obstacle.transform.position}");
            }
            else
            {
                Debug.LogError("El obstáculo no pudo ser instanciado.");
            }
        }
    }
}
