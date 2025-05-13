using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int playerLives = 3;
    public int playerScore = 0;

    public static GameManager Instance;

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
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
