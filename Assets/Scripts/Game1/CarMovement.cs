using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public GameObject[] objectsPosition; // Array de GameObjects que definen las posiciones
    private int currentPositionIndex = 0; // Índice de la posición actual

    void Start()
    {
        if (objectsPosition.Length > 0)
        {
            // Inicializa la posición del coche a la primera posición del array
            transform.position = objectsPosition[currentPositionIndex].transform.position;
        }
        else
        {
            Debug.LogError("No objects in objectsPosition array!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
    }

    public void MoveRight()
    {
        // Aumenta el índice de la posición si no estamos en el borde derecho
        if (currentPositionIndex < objectsPosition.Length - 1)
        {
            currentPositionIndex++;
            transform.position = objectsPosition[currentPositionIndex].transform.position;
        }
        playSound();
    }

    public void MoveLeft()
    {
        // Disminuye el índice de la posición si no estamos en el borde izquierdo
        if (currentPositionIndex > 0)
        {
            currentPositionIndex--;
            transform.position = objectsPosition[currentPositionIndex].transform.position;
        }
        playSound();
    }

    private void playSound()
    {
      //  this.GetComponent<AudioSource>().Play();
    }
}
