using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int playerLives = 3;
    public int playerScore = 0;

    public static GameManager Instance;
    public GameObject gameOverUI;
    public bool hasAdvanced;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            gameOverUI.SetActive(false);
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // se destruye solo si es una copia nueva
        }
    }

    void Update()
    {
        string scene = SceneManager.GetActiveScene().name;

        if (!hasAdvanced)
        {
            switch (scene)
            {
                case "Nivel1":
                    if (playerScore >= 100)
                    {
                        hasAdvanced = true;
                        SceneManager.LoadScene("Nivel2");
                    }
                    break;

                case "Nivel2":
                    if (playerScore >= 300) // Total acumulado: 100 (antes) + 200
                    {
                        hasAdvanced = true;
                        SceneManager.LoadScene("Nivel3");
                    }
                    break;
            }
        }
    }

    public void AddScore(int points)
    {
        playerScore += points;
        Debug.Log("Score: " + playerScore);
       

    }

    public void LoseLife()
    {
        playerLives--;
        Debug.Log("Lives left: " + playerLives);

        if (playerLives <= 0)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ResetGame()
    {
        playerLives = 3;
        playerScore = 0;

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }

        Time.timeScale = 1f;
    }

}
