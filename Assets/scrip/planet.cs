using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet : MonoBehaviour
{
    [SerializeReference] float velocityrotacion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calcular el ángulo de rotación
        float anguloRotacion = velocityrotacion * Time.deltaTime;

        // Calcular la rotación
        Quaternion rotacion = Quaternion.AngleAxis(anguloRotacion, Vector3.right);

        // Aplicar la rotación al objeto
        transform.rotation *= rotacion;
        
    }
}
