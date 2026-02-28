using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSelector : MonoBehaviour
{
    [Header("Genero")]
    public string genero;
    public Sprite colorPeloMujer;
    public Sprite colorPielMujer;
    public Sprite colorPeloHombre;
    public Sprite colorPielHombre;
    [Header("Genero")]
    public Sprite colorPelo;
    public Sprite colorPiel;
    public GameObject genderSelectionPanel;
    public GameObject CustomizePanel;
    public GameObject CustomizePanelMujer;
    public GameObject CustomizePanelHombre;


    public static characterSelector Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
    public void selectGender(string gender)
    {
        genero = gender;
        //QuestionsController.Instance.genero = gender;
    }
    public void SelectAndContinue()
    {
        genderSelectionPanel.SetActive(false);
        CustomizePanel.SetActive(true);
        if (genero == "Mujer") { 
            CustomizePanelMujer.SetActive(true);
            colorPiel = colorPielMujer;
            colorPelo = colorPeloMujer;
        }
        else { 
            CustomizePanelHombre.SetActive(true);
            colorPiel = colorPielHombre;
            colorPelo = colorPeloHombre;
        }

    }
   
    public void setInControllerValues()
    {
        QuestionsController.Instance.piel = colorPiel;
        QuestionsController.Instance.pelo = colorPelo;
        QuestionsController.Instance.genero = genero;

    }
}
