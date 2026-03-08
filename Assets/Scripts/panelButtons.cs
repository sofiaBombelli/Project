using UnityEngine;

public class panelButtons : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GoToContenido()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Contenido");
    }
    public void GoToCreditos()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("créditos");
    }
    public void salir()
    {
        Application.Quit();

    }
}
