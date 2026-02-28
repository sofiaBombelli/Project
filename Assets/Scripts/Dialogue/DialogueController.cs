using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [Header("woman character")]
    public GameObject WomanCharacter;
    public Image womanPiel;
    public Image womanPelo;

    [Header("Man character")]
    public GameObject manCharacter;
    public Image manPiel;
    public Image manPelo;
    [Header("External Controllers")]
    public QuestionsController QController;




    void Start()
    {
        QController = GameObject.Find("QuestionsController").GetComponent<QuestionsController>();
        loadCharacter();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void activeTimeCounter()
    {
        QController.ResetTimer();
        QController.setCounterOn(true);
    }
    public void loadCharacter()
    {
        if (QuestionsController.Instance.genero == "Mujer")
        {
            WomanCharacter.SetActive(true);
            womanPiel.sprite = QuestionsController.Instance.piel;
            womanPelo.sprite = QuestionsController.Instance.pelo;
        }
        else
        {
            manCharacter.SetActive(true);
            manPiel.sprite = QuestionsController.Instance.piel;
            manPelo.sprite = QuestionsController.Instance.pelo;
        }
    }
}
