using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroide : MonoBehaviour
{
    public float velocidadRotacion = 30.0f;  // Velocidad de rotación en grados por segundo
    public Transform centroDeRotacion;  // El punto alrededor del cual se va a rotar

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la dirección desde el objeto hacia el punto de rotación
        Vector3 direccionAlCentro = centroDeRotacion.position - transform.position;

        // Calcular el ángulo de rotación
        float anguloRotacion = velocidadRotacion * Time.deltaTime;

        // Calcular la rotación
        Quaternion rotacion = Quaternion.AngleAxis(anguloRotacion, Vector3.right);

        // Aplicar la rotación al objeto
        transform.rotation *= rotacion;

        // Mover el objeto alrededor del punto de rotación
        transform.position = centroDeRotacion.position - (rotacion * direccionAlCentro);
    }
}
