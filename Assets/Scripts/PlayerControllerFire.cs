using UnityEngine;

public class PlayerControllerFire : MonoBehaviour
{
    public GameObject WatherForm;

    public Animator animator;
    public float velocidadMovimiento = 5f;
    public float velocidadMinima = 0.01f;

    public float spamWatherTime = 0.1f;
    public float spamWatherSpeed = 0.1f;

    public float speedPlayer = 1f;

    public void ShootWater()
    {
        if(Time.time - spamWatherTime > spamWatherSpeed)
        {
            GameObject instance = Instantiate(WatherForm, this.transform.position, this.transform.rotation, this.transform);
            //instance.transform.SetParent(this.transform);
            spamWatherTime = Time.time;
        }
    }

    public void SpawnObject()
    {

    }

    void Update()
    {
        // Obtener input de manera más limpia
        float movimientoHorizontal = 0f;
        float movimientoVertical = 0f;

        float minX = -35f;
        float maxX = +35f;
        float minZ = -20f;
        float maxZ = +20f;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            if ((transform.position.x + speedPlayer) >= minZ)
                movimientoVertical = speedPlayer;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            if ((transform.position.x + speedPlayer) <= maxZ)
                movimientoVertical = -speedPlayer;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            if ((transform.position.x + speedPlayer) >= minX)
                movimientoHorizontal = -speedPlayer;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            if ((transform.position.x + speedPlayer) <= maxX)
                movimientoHorizontal = speedPlayer;

        if (Input.GetKey(KeyCode.Space)) ShootWater();

        // Crear vector y verificar si hay movimiento
        Vector3 direccionMovimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);

        // Actualizar animación basado en si hay movimiento
        animator.SetBool("walk", direccionMovimiento.magnitude > velocidadMinima);

        // Aplicar movimiento (solo si hay input)
        if (direccionMovimiento.magnitude > velocidadMinima)
        {
            // Normalizar para velocidad consistente en diagonal
            direccionMovimiento.Normalize();
            transform.Translate(direccionMovimiento * velocidadMovimiento * Time.deltaTime);
            //animator.SetBool("idle", false);
            /*
            this.transform.rotation = Quaternion.LookRotation(
                new Vector2(
                    direccionMovimiento.normalized.x,
                    direccionMovimiento.normalized.y),
                Vector3.up);
            */
        }
        else
        {
            animator.SetBool("idle", true);
        }
    }

}
