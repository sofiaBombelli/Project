using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToNextScene : MonoBehaviour
{
    public Image fadeImage; // Referencia a la imagen usada para el fade

    public string sceneToLoad; // Nombre de la escena a cargar
    public float fadeDuration = 1f; // Duración del fade en segundos
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public KeyCode keyToDetect = KeyCode.Space; // Puedes cambiar esto a la tecla que desees detectar

    void Update()
    {
        if (Input.GetKeyDown(keyToDetect))
        {
            GoToNext();
        }
    }
    public void GoToNext()
    {
        StartCoroutine(FadeOutAndChangeScene());
    }
    public void GoToNextButDelayed()
    {
        StartCoroutine(FadeOutAndChangeSceneDelayed());
    }


    
    IEnumerator FadeOutAndChangeScene()
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;
       
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            
            fadeImage.color = color;
     
            yield return null;
        }

        // Cambiar de escena después del fade-out
        SceneManager.LoadScene(sceneToLoad);
    }
    IEnumerator FadeOutAndChangeSceneDelayed()
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeOutAndChangeScene());
    }
}
