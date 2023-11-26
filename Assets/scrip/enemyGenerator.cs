using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGenerator : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs = new List<GameObject>(); // Lista de prefabs de obst�culos
    public List<Transform> spawnPoints = new List<Transform>(); // Puntos de generaci�n predefinidos

    public float spawnInterval = 2f; // Intervalo de tiempo entre generaci�n de obst�culos

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Seleccionar aleatoriamente un punto de generaci�n de la lista
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

            // Seleccionar aleatoriamente un obst�culo de la lista
            GameObject selectedObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

            // Generar el obst�culo en el punto seleccionado
            GameObject newObstacle = Instantiate(selectedObstacle, spawnPoint.position, Quaternion.identity);
            // Ajustar el movimiento, rotaci�n o comportamiento del obst�culo si es necesario
        }
    }
}




