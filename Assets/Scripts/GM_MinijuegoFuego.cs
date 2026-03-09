using UnityEngine;

public class GM_MinijuegoFuego : MonoBehaviour
{

    public float timeToFinish=75f;
    public float timeStart;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTime();
    }

    public void CheckTime()
    {
        if(Time.time - timeStart >= timeToFinish)
        {
            //Debug.Log("END!!!!" + timeToFinish);
            UnityEngine.SceneManagement.SceneManager.LoadScene("PantallaFinal");
        }
        else
        {
            //Debug.Log("OnGame: " + (Time.time - timeStart));
        }
    }
}
