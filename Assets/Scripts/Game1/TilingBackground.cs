using UnityEngine;

public class TilingBackground : MonoBehaviour
{
    public float scrollSpeed = 0.5f; // Velocidad de desplazamiento del fondo
    private Vector2 offset;
    private Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset = new Vector2( 0, Time.deltaTime * scrollSpeed);
        material.mainTextureOffset = offset;
    }
}
