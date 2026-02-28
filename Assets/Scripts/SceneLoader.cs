using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnSceneLoad : MonoBehaviour
{
    public enum scenes
    {
        Login,
        Carta,
        Cueva,
        Carpa,
        Crack,
        Montania1,
        Pregunta_1,
        Pregunta_2,
        Pregunta_3,
        MiniJuego_1,
        MiniJuego_2,
        MiniJuego_3,
        HoraDeCorrer_nieve,
        HoraDeCorrer_desierto,
        HoraDeCorrer_carrera,
        HoraDeCorrer_castillo,
        MiniJuego_3_nieve,
        MiniJuego_3_desierto,
        MiniJuego_3_carrera,
        MiniJuego_3_castillo,
        MiniJuego_4,
        End,
        mapaInteractivo,
        Formulario,
        Pregunta_4,
        Pregunta_5,
        MiniJuego_5,
        Pregunta_6,
        MiniJuego_6,
        Pregunta_7,
        MiniJuego_7,
        Pregunta_8,
        MiniJuego_8,


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
