using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public enum scenes
    {
       MainMenu,
       Intro,
       MapaInteractivo,
       MemoTest,
       MinijuegoFuego,
       PantallaResultadosFuego,
       PantallaFinal
    }

    [Header("Scene selection")]
    public scenes nextScene;
    public Button buttonNext;

    [Header("Fade Settings")]
    public Image fadeImage;
    public float fadeDuration;

    void Start()
    {// Ensure the button reference is set

        
        if (buttonNext != null)
        {
            // Add a listener to the onClick event
            buttonNext.onClick.AddListener(OnButtonClicked);
        }
        else
        {
            Debug.LogError("Button reference is not set!");
        }

        //la imagen queda con el alpha en 0
        if (fadeImage != null)
        {
            var c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;
        }

    }
    public void OnButtonClicked()
    {
        StartCoroutine(FadeOutAndLoadScene());
        //Debug.Log("Button Clicked!");
    }

    public IEnumerator FadeOutAndLoadScene()
    {
        //si no esta conectada la imagen no se hace el fade
        if (fadeImage == null)
        {
            SceneManager.LoadScene(nextScene.ToString());
            yield break;
        }

        float elapsed = 0f;
        Color c = fadeImage.color;

        // Fade
        while (elapsed < fadeDuration)
        {
            elapsed += Time.unscaledDeltaTime;
            c.a = Mathf.Clamp01(elapsed / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "mapaInteractivo")
        {
            Debug.Log("Estoy en el mapa");           
        }

        yield return new WaitForSeconds(0.7f);
        gotonextscene();
    }

    public void gotonextscene()
    {
       SceneManager.LoadScene(nextScene.ToString());
    }
}
