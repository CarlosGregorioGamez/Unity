using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int playerLives;
    public int playerScore;

    public static GameManager Instance;
    public GameObject gameOverUI;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            gameOverUI.SetActive(false);  
            playerLives = 3;
            playerScore = 0;   
        }
        else
        {
            Destroy(gameObject);
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
}
