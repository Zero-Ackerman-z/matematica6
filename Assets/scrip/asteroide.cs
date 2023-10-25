using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroide : MonoBehaviour
{
    public float velocidadRotacion = 30.0f;  // Velocidad de rotaci�n en grados por segundo
    public Transform centroDeRotacion;  // El punto alrededor del cual se va a rotar

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la direcci�n desde el objeto hacia el punto de rotaci�n
        Vector3 direccionAlCentro = centroDeRotacion.position - transform.position;

        // Calcular el �ngulo de rotaci�n
        float anguloRotacion = velocidadRotacion * Time.deltaTime;

        // Calcular la rotaci�n
        Quaternion rotacion = Quaternion.AngleAxis(anguloRotacion, Vector3.right);

        // Aplicar la rotaci�n al objeto
        transform.rotation *= rotacion;

        // Mover el objeto alrededor del punto de rotaci�n
        transform.position = centroDeRotacion.position - (rotacion * direccionAlCentro);
    }
}
