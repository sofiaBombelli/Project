using UnityEngine;
using UnityEngine.UI;

public class TilingBackgroundUI : MonoBehaviour
{
    public float scrollSpeed = 0.5f; // Velocidad de desplazamiento del fondo
    private RawImage rawImage;
    private Rect uvRect;

    void Start()
    {
        rawImage = GetComponent<RawImage>();
        uvRect = rawImage.uvRect;
    }

    void Update()
    {
        uvRect.y += scrollSpeed * Time.deltaTime;
        rawImage.uvRect = uvRect;
    }
}
