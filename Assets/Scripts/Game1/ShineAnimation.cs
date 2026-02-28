using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShineAnimation : MonoBehaviour
{
    public Sprite[] sprites; // Array de sprites para la animación
    public float frameRate = 0.15f; // Duración de cada frame en segundos
    public bool rotate;
    public Image spriteRenderer;
    private int currentFrame;
    private float timer;

    void Start()
    {
        if (sprites.Length > 0)
        {
            spriteRenderer.sprite = sprites[0];
        }
    }

    public void ActiveSpark()
    {
        currentFrame = 0; // Reiniciar el frame actual
        timer = 0; // Reiniciar el temporizador
        spriteRenderer.sprite = sprites[0]; // Establecer el primer sprite
        rotate = true;
     //   StartCoroutine(wait());
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
       
        
    } 

    void Update()
    {
        if (rotate)
        {
            if (sprites.Length == 0) return;

            timer += Time.deltaTime;

            if (timer >= frameRate)
            {
                timer -= frameRate;
                currentFrame++;

                if (currentFrame >= sprites.Length)
                {
                    rotate = false; // Detener la animación después de un ciclo completo
                    currentFrame = 0; // Reiniciar el frame actual (opcional)
                }
                else
                {
                    spriteRenderer.sprite = sprites[currentFrame];
                }
            }
        }
    }
}
