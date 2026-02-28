using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage; // Referencia a la imagen usada para el fade
    public Text fadeText;
    public string sceneToLoad; // Nombre de la escena a cargar
    public float fadeDuration = 1f; // Duración del fade en segundos

    void Start()
    {
        // Iniciar con fade-in
        //  StartCoroutine(FadeIn());
        StartCoroutine(changeScene());
    }

    public void ChangeScene()
    {
        // Iniciar fade-out y luego cambiar de escena
        StartCoroutine(FadeOutAndChangeScene());
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;
       // Color colorText = fadeText.color;

        while (elapsedTime < fadeDuration)
        {
            /*elapsedTime += Time.deltaTime;
            color.a = 1f - Mathf.Clamp01(elapsedTime / fadeDuration);
           // colorText.a = 1f - Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = color;
           // fadeText.color = colorText;*/
            yield return null;
        }
        ChangeScene();
    }
    private IEnumerator changeScene()
    {
        yield return new WaitForSecondsRealtime(4);
        this.GetComponent<GoToNextScene>().GoToNext();
        //SceneManager.LoadScene(sceneToLoad);
    }

    IEnumerator FadeOutAndChangeScene()
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;
      //  Color colorText = fadeText.color;
        while (elapsedTime < fadeDuration)
        {/*
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
         //   colorText.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeImage.color = color;
          //  fadeText.color = color;*/
            yield return null;
        }

        // Cambiar de escena después del fade-out
        
    }
}
