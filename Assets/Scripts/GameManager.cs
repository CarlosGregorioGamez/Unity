using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int playerLives = 3;
    public int playerScore = 0;

    public static GameManager Instance;
    public GameObject gameOverUI;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            gameOverUI.SetActive(false);
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // se destruye solo si es una copia nueva
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
