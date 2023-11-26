using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Velocidad de movimiento del avi�n
    public float rotationAngle = 35.0f; // �ngulo de rotaci�n del avi�n
    public float maxXLimit = 5.0f; // L�mite m�ximo en el eje X
    public float minXLimit = -5.0f; // L�mite m�nimo en el eje X
    public float maxYLimit = 15.0f; // L�mite m�ximo en el eje Y
    public float minYLimit = -8.0f; // L�mite m�nimo en el eje Y
    public int playerLives = 3; // Cantidad inicial de vidas del jugador

    void Update()
    {
        // Obtener las entradas del teclado
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular el desplazamiento en funci�n de las entradas de movimiento
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;

        // Aplicar el desplazamiento
        transform.Translate(movement);

        // Limitar la posici�n del avi�n dentro de los l�mites establecidos
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minXLimit, maxXLimit);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minYLimit, maxYLimit);
        transform.position = clampedPosition;

        // Calcular la rotaci�n en funci�n de la direcci�n de movimiento
        float rotation = 0;

        if (horizontalInput < 0)
        {
            rotation = -rotationAngle; // Rotar a la izquierda
        }
        else if (horizontalInput > 0)
        {
            rotation = rotationAngle; // Rotar a la derecha
        }

        // Rotar el avi�n
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
    void OnTriggerEnter(Collider other)
    {
       Game_Manager gameManager = FindObjectOfType<Game_Manager>();
            if (gameManager != null)
            {
                gameManager.DecreaseLives(); // Aumenta el contador de golpes
            }

            Destroy(other.gameObject); // Destruye el obst�culo al colisionar con el jugador
    }
}



