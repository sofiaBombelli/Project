using UnityEngine;

public class PlayerControllerFire : MonoBehaviour
{
    public Animator animator;
    public float velocidadMovimiento = 5f;
    void Update()
    {
        // Movimiento horizontal (A y D)
        float movimientoHorizontal = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            movimientoHorizontal = -1f; // Moverse a la izquierda
        }
        if (Input.GetKey(KeyCode.D))
        {
            movimientoHorizontal = 1f; // Moverse a la derecha
        }

        // Movimiento vertical/adelante (W y S)
        float movimientoVertical = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            movimientoVertical = 1f; // Moverse adelante
        }
        if (Input.GetKey(KeyCode.S))
        {
            movimientoVertical = -1f; // Moverse atrás
        }

        // Crear vector de movimiento
        Vector3 direccionMovimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);

        // Verificar si hay movimiento (cualquier tecla WASM presionada)
        bool estaCaminando = (movimientoHorizontal != 0f || movimientoVertical != 0f);

        // Actualizar el parámetro del animator
        animator.SetBool("walk", estaCaminando);

        // Normalizar para que la diagonal no sea más rápida
        if (direccionMovimiento.magnitude > 1f)
        {
            direccionMovimiento.Normalize();
        }

        // Aplicar movimiento
        transform.Translate(direccionMovimiento * velocidadMovimiento * Time.deltaTime);
    }


}
