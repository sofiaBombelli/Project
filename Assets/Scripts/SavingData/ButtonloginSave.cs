using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SavebyButton : MonoBehaviour
{
    //public InputField Name;
    public TMP_InputField Name;
    public TMP_InputField mail;
  //  public InputField mail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void savedataInQuestionController()
    {
        QuestionsController.Instance.nombre = Name.text;
        QuestionsController.Instance.mail = mail.text;
    }
}
