using UnityEngine;

public class Timer : MonoBehaviour
{
    float tiempoActual;
    float startTime = 1;
    void Start()
    {
        tiempoActual = startTime;
    }
    //---Timer---

    void Update()
    {
        tiempoActual -= Time.deltaTime;

        if (tiempoActual <= 0)
        {
            tiempoActual = 0;
            TimerFinished();
        }

        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        float minutes = Mathf.FloorToInt(tiempoActual / 60);
        float seconds = Mathf.FloorToInt(tiempoActual % 60);
      //  tiempoRestanteText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimerFinished()
    {
        Debug.Log("¡Tiempo terminado!");
      //  sceneLoader.OnButtonClicked();
    }
}
