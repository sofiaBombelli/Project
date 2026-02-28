using UnityEngine;
using UnityEngine.UI;

public class CoinAnimation : MonoBehaviour
{
    public Sprite[] sprites; // Array de sprites para la animación
    public float frameRate = 0.1f; // Duración de cada frame en segundos
    public bool rotate;
    public Image spriteRenderer;
    private int currentFrame;
    private float timer;
    

    void Start()
    {
        //spriteRenderer = GetComponent<Image>();
      
        if (sprites.Length > 0)
        {
            spriteRenderer.sprite = sprites[0];
        }
    }
    public void activeMovement()
    {
       
        LeanTween.move(this.gameObject, new Vector3(Screen.width/2, Screen.height/2, 0), 0.2f).setEase(LeanTweenType.easeInQuart);
        LeanTween.scale(this.gameObject, new Vector2(1.1f, 1.1f), 0.5f);
        rotate = true;
        LeanTween.scale(this.gameObject, new Vector2(0f, 0f), 0.3f).setDelay(0.5f);
        
    }
    void Update()
    {
        if (rotate) { 
            if (sprites.Length == 0) return;

            timer += Time.deltaTime;

            if (timer >= frameRate)
            {
                timer -= frameRate;
                currentFrame = (currentFrame + 1) % sprites.Length;
                spriteRenderer.sprite = sprites[currentFrame];
            }
        }
    }
}
