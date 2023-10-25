using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public float velocidad = 10.0f;
    public float rotacionSpeed = 35.0f;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento del avión
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(horizontalInput, verticalInput, 0) * velocidad * Time.deltaTime;

        // Calcular la rotación del avión
        Quaternion rotacion = Quaternion.Euler(0, 0, -horizontalInput * rotacionSpeed * Time.deltaTime);

        // Aplicar la rotación
        transform.rotation *= rotacion;

        // Actualizar la posición
        transform.position += movimiento;
    }

}

