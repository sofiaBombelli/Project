using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{

    public GameObject[] mapElements;// Array of map elements to control  
    public int mapaElementIndex = 0; 
    void Start()
    {
        //Validar qué elemento está activo y mostrarlo en el mapa
        for (int i = 0; i < mapElements.Length; i++)
        {
            if (i == mapaElementIndex)
            {
                mapElements[i].SetActive(true); // Activar el elemento actual
            }
            else
            {
                mapElements[i].SetActive(false); // Desactivar los demás elementos
            }
        }
    }

}
