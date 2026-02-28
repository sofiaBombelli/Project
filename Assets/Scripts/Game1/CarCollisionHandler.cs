using UnityEngine;

public class CarCollisionHandler : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("Colisión con obstáculo!");
        if (collision.gameObject.CompareTag("Gemas"))
        {
            // Lógica cuando el coche colisiona con un obstáculo
            Debug.Log("Colisión con obstáculo!");
            QuestionsController.Instance.sumarGemas();

            // Por ejemplo, podrías destruir el coche o detener el juego
            Destroy(collision.gameObject);
        }else if (collision.gameObject.CompareTag("Obstaculo")){
            QuestionsController.Instance.failCollision();
            Destroy(collision.gameObject);
        }
    }
}
