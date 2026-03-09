using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;

public class fadeMapa : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 2f;

    void Start()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(10);
        float elapsedTime = 0f;
        float startAlpha = canvasGroup.alpha;
        float targetAlpha = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
    }
}
