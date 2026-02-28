using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeCharacter : MonoBehaviour
{
    [Header("Pelo")]
    public GameObject customizePanelPelo;
    public GameObject[] PeloObjects;
    [Header("Piel")]
    public GameObject customizePanelPiel;
    public GameObject[] PielObjects;
    public int selectedCharacter = 0;
    [Header("Color Selected")]
    public Sprite pielColor;
    public Sprite peloColor;
    public int colorPiel;
    public int colorPelo;

    // Start is called before the first frame update
    void Start()
    {
        HideAllCharacters();

        PeloObjects[selectedCharacter].SetActive(true);
        PielObjects[selectedCharacter].SetActive(true);
        QuestionsController.Instance.pelo = PeloObjects[0].GetComponent<Image>().sprite;
        QuestionsController.Instance.piel = PielObjects[0].GetComponent<Image>().sprite;
    }
    private void HideAllCharacters()
    {
        foreach (GameObject g in PeloObjects)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in PielObjects)
        {
            g.SetActive(false);
        }
    }
    //PELO
    public void NextCharacterPelo()
    {
        PeloObjects[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter >= PeloObjects.Length)
        {
            selectedCharacter = 0;
        }
        PeloObjects[selectedCharacter].SetActive(true);
        characterSelector.Instance.colorPelo = PeloObjects[selectedCharacter].GetComponent<Image>().sprite;
        QuestionsController.Instance.colorPelo = selectedCharacter;
    }

    public void PreviousCharacterPelo()
    {
        PeloObjects[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter = PeloObjects.Length - 1;
        }
        PeloObjects[selectedCharacter].SetActive(true);
        characterSelector.Instance.colorPelo = PeloObjects[selectedCharacter].GetComponent<Image>().sprite;
        QuestionsController.Instance.colorPelo = selectedCharacter;
    }
    //PIEL
    public void NextCharacterPiel()
    {
        PielObjects[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter >= PielObjects.Length)
        {
            selectedCharacter = 0;
        }
        PielObjects[selectedCharacter].SetActive(true);
        characterSelector.Instance.colorPiel = PielObjects[selectedCharacter].GetComponent<Image>().sprite;
        QuestionsController.Instance.colorPiel = selectedCharacter;
       

    }

    public void PreviousCharacterPiel()
    {
        PielObjects[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter = PeloObjects.Length - 1;
        }
        PielObjects[selectedCharacter].SetActive(true);
        characterSelector.Instance.colorPiel = PielObjects[selectedCharacter].GetComponent<Image>().sprite;
        QuestionsController.Instance.colorPiel = selectedCharacter;
       
    }
}
