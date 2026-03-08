using Unity.VisualScripting;
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

        mapElements[0].GetComponent<Button>().onClick.AddListener(() => OnButtonMapClicked(1));
        mapElements[1].GetComponent<Button>().onClick.AddListener(() => OnButtonMapClicked(2));
        mapElements[2].GetComponent<Button>().onClick.AddListener(() => OnButtonMapClicked(3));
    }

    private void OnButtonMapClicked(int index) { 
        switch (index)
        {
            case 0:
                DataController.Instance.etapaActual = 1;
                break;
            case 1:
                DataController.Instance.etapaActual = 2;
                break;
            case 2:
                DataController.Instance.etapaActual = 3;
                break;
        }

    }
}
