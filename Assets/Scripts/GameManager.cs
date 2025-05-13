using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int playerLives = 3;
    public int playerScore = 0;

    public static GameManager Instance;
    public GameObject gameOverPrefab;
    public GameObject gameOverUI;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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
            if (gameOverUI == null)
            {
                gameOverUI = Instantiate(gameOverPrefab);
            }
        }
    }
}
