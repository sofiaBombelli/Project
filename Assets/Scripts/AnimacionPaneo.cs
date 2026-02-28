using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionPaneo : MonoBehaviour
{
    public Transform panel;
    public bool isGoingToRightSide = true;
    public float panDistance = 500f; // Distancia a recorrer
    public float panDuration = 1f; // Duración de la transición
    public AnimationCurve panCurve = AnimationCurve.EaseInOut(0, 0, 1, 1); // Curva de suavizado

    [Header("Posiciones")]
    public Vector3 startPosition; // Posición inicial (izquierda)
    public Vector3 endPosition; // Posición final (derecha)
    
    void Start()
    {
        if (panel != null)
        {
            startPosition = panel.position;
            endPosition = new Vector3(startPosition.x + panDistance, startPosition.y, startPosition.z);
        }

        if (isGoingToRightSide)
        {
            PanRightToLeft();
        }
        else {
            PanLeftToRight(); 
        }

    }

    // Método para paneo izquierda a derecha
    public void PanLeftToRight()
    {
        StopAllCoroutines();
        StartCoroutine(PanCoroutine(startPosition, endPosition));
    }

    // Método para paneo derecha a izquierda (regreso)
    public void PanRightToLeft()
    {
        StopAllCoroutines();
        StartCoroutine(PanCoroutine(endPosition, startPosition));
    }

    IEnumerator PanCoroutine(Vector3 from, Vector3 to)
    {
        float elapsedTime = 0;

        while (elapsedTime < panDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / panDuration;

            // Aplicar curva de animación
            float curveValue = panCurve.Evaluate(t);

            // Interpolar posición
            panel.position = Vector3.Lerp(from, to, curveValue);

            yield return null;
        }

        // Asegurar posición final exacta
        panel.position = to;
    }


}
