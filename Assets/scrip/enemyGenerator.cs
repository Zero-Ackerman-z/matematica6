using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGenerator : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs = new List<GameObject>(); // Lista de prefabs de obstáculos
    public List<Transform> spawnPoints = new List<Transform>(); // Puntos de generación predefinidos

    public float spawnInterval = 2f; // Intervalo de tiempo entre generación de obstáculos

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Seleccionar aleatoriamente un punto de generación de la lista
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

            // Seleccionar aleatoriamente un obstáculo de la lista
            GameObject selectedObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

            // Generar el obstáculo en el punto seleccionado
            GameObject newObstacle = Instantiate(selectedObstacle, spawnPoint.position, Quaternion.identity);
            // Ajustar el movimiento, rotación o comportamiento del obstáculo si es necesario
        }
    }
}




