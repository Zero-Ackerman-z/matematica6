using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AsteroideController : MonoBehaviour
{
    public float speed = 3f; // Velocidad de movimiento del obstáculo
    public Transform player; // Referencia al jugador (avión)
    private Rigidbody rb;

    void Update()
    {
        if (player != null)
        {
            // Calcular la dirección hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;

            // Calcular el movimiento hacia el jugador
            Vector3 targetPosition = transform.position + direction * speed * Time.fixedDeltaTime;

            // Mover el obstáculo hacia el jugador usando Rigidbody
            rb.MovePosition(targetPosition);
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Si colisiona con el jugador, desaparece el obstáculo
            Destroy(gameObject);
        }
    }
}
