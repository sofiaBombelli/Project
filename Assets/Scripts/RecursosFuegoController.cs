using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecursosFuegoController : MonoBehaviour
{
    public float porcentajeFuego;
    public Image imageToFill;
    public TextMeshProUGUI textToShow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        porcentajeFuego= DataController.Instance.puntajeObtenidoFuego;
        textToShow.text = "Tus recursos son del "+ porcentajeFuego.ToString()+"%";
        imageToFill.fillAmount = porcentajeFuego/100;
        Debug.Log("Porcentaje fuego: " + porcentajeFuego / 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
