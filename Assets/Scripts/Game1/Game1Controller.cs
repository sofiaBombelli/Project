using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Controller : MonoBehaviour
{
    public float durationTime;
    float time;
    public GoToNextScene go;
    public GameObject[] character;
    public CarMovement movimiento;
    int color;
    void Start()
    {
        //character = GameObject.FindGameObjectWithTag("ChiviCharacter");
        color = QuestionsController.Instance.colorPiel;
        setCharacterColor();
        
    }

    void setCharacterColor()
    {
        switch (color)
        {
            case 0:
                character[0].SetActive(true);
                break;

            case 1:
                character[1].SetActive(true);
                break;

            case 2:
                character[2].SetActive(true);
                break;

            case 3:
                character[3].SetActive(true);
                break;
        }
        movimiento = character[color].GetComponent<CarMovement>();
    }

    void Update()
    {
        if(time <= durationTime) { 
            time += Time.deltaTime;        
            Debug.Log("time:" + (int)time);
        }
        else
        {
            finishLevel();
        }

    }
    public void MoveLeft() { movimiento.MoveLeft(); }
    public void MoveRight() { movimiento.MoveRight(); }

    private void finishLevel()
    {
        go.GoToNext();
    }
}
