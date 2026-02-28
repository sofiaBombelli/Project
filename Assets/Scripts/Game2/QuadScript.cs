using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadScript : MonoBehaviour
{
    float[] rotations = { 0, 90, 180, 270 };
    [Header("Forced pipe")]
    public bool isRotationToBeDefined;
    public int necessaryRotation;

    [Header("Special pipe")]
    public bool hasMoreCorrectRotations;
    [Header("Correct Rotations")]
    public int correctRotation1;
    public int correctRotation2;
    public Action OnButtonClick; // Definición del Action
    public float aniSpeed = 0.5f; // Velocidad de fade in/out 
    public float rotSpeed; // Vamos a hacerlo por interpolación. 

    bool isPlayable = true;
    private float ani = 0.0f;
    private bool estaPosicionado1 = false; // Determina si está posicionado en la primera posición correcta.
    private bool estaPosicionado2 = false; // Determina si está posicionado en la segunda posición correcta.
    private bool isRotating;
    public Game2Controller gmanager;
    bool isGameOver;
    [Header("Sound")]
    public AudioSource sonidoGiro;

    private float rotAni = 0; // Posición del LERP.
    private float rotPrev; // Guardamos la rotación anterior.

    private void Start()
    {
        sonidoGiro = GetComponentInParent<AudioSource>();
        gmanager = transform.parent.gameObject.GetComponent<Game2Controller>();

        correctRotation1 = Mathf.FloorToInt(transform.eulerAngles.z);
        setRandomRotationToPipes();

        // Asigna una función al Action.
        OnButtonClick += HandleButtonAction;

        // Configura el evento OnClick del botón para llamar al Action.
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }

    public void Update()
    {
        if (isRotating)
        {
            rotAni += rotSpeed;
            float actualrot = Mathf.Lerp(rotPrev, rotPrev + 90f, rotAni);
            rotAni = Mathf.Clamp(rotAni, 0.0f, 1.0f);
            transform.eulerAngles = new Vector3(0, 0, actualrot);
        }

        // Si termina la rotación.
        if (rotAni == 1)
        {
            rotPrev = transform.eulerAngles.z;
            rotAni = 0;
            isRotating = false;
            checkIfPosicionado();
        }
    }

    private void setRandomRotationToPipes()
    {
        if (isRotationToBeDefined)
        {
            transform.eulerAngles = new Vector3(0, 0, necessaryRotation);
        }
        else
        {
            int rand;
            do
            {
                rand = UnityEngine.Random.Range(0, rotations.Length);
                transform.eulerAngles = new Vector3(0, 0, rotations[rand]);
            } while (transform.eulerAngles.z == correctRotation1 || transform.eulerAngles.z == correctRotation2);
        }
    }

    private void OnClickButton()
    {
        if (isPlayable)
        {
            // Llama al Action.
            OnButtonClick?.Invoke();
        }
    }

    public void HandleButtonAction()
    {
        if (!isRotating)
        {
            isRotating = true;
            rotPrev = transform.eulerAngles.z;
            sonidoGiro.Play();
        }
    }

    private void checkIfPosicionado()
    {
        int angle = Mathf.FloorToInt(transform.eulerAngles.z) % 360;
        angle = (angle < 0) ? angle + 360 : angle;

        int correctAngle1 = correctRotation1 % 360;
        correctAngle1 = (correctAngle1 < 0) ? correctAngle1 + 360 : correctAngle1;

        int correctAngle2 = correctRotation2 % 360;
        correctAngle2 = (correctAngle2 < 0) ? correctAngle2 + 360 : correctAngle2;

        bool isCurrentlyPositioned1 = (angle == correctAngle1);
        bool isCurrentlyPositioned2 = (angle == correctAngle2);

        if (isCurrentlyPositioned1 && !estaPosicionado1)
        {
            estaPosicionado1 = true;
            gmanager.totalCorrectQuads1++;
        }
        else if (!isCurrentlyPositioned1 && estaPosicionado1)
        {
            estaPosicionado1 = false;
            gmanager.totalCorrectQuads1--;
        }

        if (isCurrentlyPositioned2 && !estaPosicionado2)
        {
            estaPosicionado2 = true;
            gmanager.totalCorrectQuads2++;
        }
        else if (!isCurrentlyPositioned2 && estaPosicionado2)
        {
            estaPosicionado2 = false;
            gmanager.totalCorrectQuads2--;
        }
    }

    private void changePipeColor()
    {
        if (estaPosicionado1 || estaPosicionado2)
        {
            ani += aniSpeed;
            Color lerpedColor = Color.Lerp(Color.white, new Color32(255, 231, 0, 255), ani);
            this.GetComponent<Image>().color = lerpedColor;
        }
        else
        {
            ani -= aniSpeed;
        }
        ani = Mathf.Clamp(ani, 0.0f, 1.0f);
    }

    private void changePipeColorWhenIsCorrectPositioned()
    {
        // Implementación para cambiar el color cuando está correctamente posicionado.
    }
}
