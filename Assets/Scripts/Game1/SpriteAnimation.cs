using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    public float changeInterval = 1f;

    private Image sprite;
    private float timer;
    private int currentSpriteIndex;

    void Start()
    {
        if (sprites.Length == 0)
        {
            Debug.LogError("No sprites assigned.");
            return;
        }

        sprite = GetComponent<Image>();
        timer = 0f;
        currentSpriteIndex = 0;
        sprite.sprite = sprites[currentSpriteIndex];
    }

    void Update()
    {
        if (sprites.Length == 0) return;

        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            timer = 0f;
            SwapSprite();
        }
    }

    void SwapSprite()
    {
        currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length;
        sprite.sprite = sprites[currentSpriteIndex];
    }
}

