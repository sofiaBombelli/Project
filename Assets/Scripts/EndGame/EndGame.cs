using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text GemasTotales;

    // Start is called before the first frame update
    void Start()
    {
        GemasTotales.text = QuestionsController.Instance.GemasRecolectadas.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void usarGemas()
    {

    }
    public void noUsarGemas()
    {

    }
}
