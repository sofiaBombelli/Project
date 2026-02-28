using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float fallSpeed = 700; // Velocidad de caída del obstáculo
    public bool notDestroy = false;
    void Update()
    {
        // Mover el obstáculo hacia abajo
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        if(notDestroy == false) { 
            // Destruir el obstáculo si sale de la pantalla
            if (transform.position.y < -10f) // Ajusta este valor según tu escena
            {
                Destroy(gameObject);
            }
        }
    }
}
