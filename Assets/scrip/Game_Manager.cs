using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Game_Manager : MonoBehaviour
{
    public TMP_Text scoreText; // Referencia al objeto de texto para mostrar el puntaje
    public TMP_Text livesText;
    private int maxHits = 3; // Número máximo de golpes antes de terminar el juego
    private int playerHits = 0; // Contador de golpes recibidos
    private float flyingTime = 0.0f; // Tiempo que el jugador está volando
    private int score = 0; // Puntaje del jugador
    private int hitsRemaining; // Número de golpes restantes antes de terminar el juego
    private bool gameEnded = false; // Variable para controlar el fin del juego

    void Start()
    {
        hitsRemaining = maxHits;
        UpdateScoreUI();
        UpdateLivesUI();
    }

    void Update()
    {
        if (!gameEnded)
        {
            flyingTime += Time.deltaTime;
            score = Mathf.FloorToInt(flyingTime);
            UpdateScoreUI();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!gameEnded && collision.gameObject.CompareTag("Obstacle")) // Cambia "Obstacle" por la etiqueta de tus obstáculos
        {
            hitsRemaining--;
            UpdateLivesUI();

            if (hitsRemaining <= 0)
            {
                EndGame();
            }
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void DecreaseLives()
    {
        playerHits++;
        UpdateLivesUI();

        if (playerHits >= maxHits)
        {
            EndGame();
        }
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Hits: " + playerHits.ToString() + " / " + maxHits.ToString();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over");
        // Aquí puedes añadir más lógica para mostrar un mensaje de Game Over, reiniciar el nivel, etc.
        // SceneManager.LoadScene("NombreDeTuEscenaGameOver"); // Reiniciar el juego, si es necesario
    }
}
