using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDecision : MonoBehaviour
{
    [Header("Respuestas")]
    public int Nivel;
    public int respuestaNro;
    
    [Header("puntajes")]
    public int pregunta;
    //public int puntajeRespuesta;
   // public int BonoTiempo;
    [Header("Imagenes")]
    public GameObject[] BotonesImage;


    // Start is called before the first frame update
    void Start()
    {
        BotonesImage = GameObject.FindGameObjectsWithTag("Boton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void elegir()
    {
        QuestionsController.Instance.respuestas[Nivel-1] = respuestaNro;
      //  QuestionsController.Instance.sumatoriaPuntaje( puntajeRespuesta);
        QuestionsController.Instance.guardarRespuestaTiempo(Nivel-1);
        foreach (GameObject boton in BotonesImage)
        {
            // Ejemplo de operación: desactivar el botón
            boton.GetComponent<Image>().color = new Color(255,255,255,0);
                
        }
    }
}
