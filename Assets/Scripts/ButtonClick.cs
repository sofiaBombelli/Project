using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedButton : MonoBehaviour
{
    public Button seedButton;

    // Start is called before the first frame update
    void Start()
    {
        seedButton.onClick.AddListener(OnSeedButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnSeedButtonClick()
    {
       Debug.Log("¡Botón de semilla presionado!");

        
    }

    
}
