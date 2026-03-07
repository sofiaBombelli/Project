using UnityEngine;

public class PlayerControllerFire : MonoBehaviour
{
    public Animator animator;
    public float velocidadMovimiento = 5f;

    void Update()
    {
        // Obtener input de manera más limpia
        float movimientoHorizontal = 0f;
        float movimientoVertical = 0f;

        if (Input.GetKey(KeyCode.W)) movimientoVertical = 1f;
        if (Input.GetKey(KeyCode.S)) movimientoVertical = -1f;
        if (Input.GetKey(KeyCode.A)) movimientoHorizontal = -1f;
        if (Input.GetKey(KeyCode.D)) movimientoHorizontal = 1f;

        // Crear vector y verificar si hay movimiento
        Vector3 direccionMovimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);

        // Actualizar animación basado en si hay movimiento
        animator.SetBool("walk", direccionMovimiento.magnitude > 0);

        // Aplicar movimiento (solo si hay input)
        if (direccionMovimiento.magnitude > 0)
        {
            // Normalizar para velocidad consistente en diagonal
            direccionMovimiento.Normalize();
            transform.Translate(direccionMovimiento * velocidadMovimiento * Time.deltaTime);
        }
    }

}
