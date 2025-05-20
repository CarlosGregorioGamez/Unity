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
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Elimina copias duplicadas
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Esto se llama automáticamente al cargar cada escena
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject ui = GameObject.Find("GameOverUI");
        if (ui != null)
        {
            gameOverUI = ui;
            gameOverUI.SetActive(false); // Asegúrate de que no aparezca al cargar
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
                    if (playerScore >= 300)
                    {
                        hasAdvanced = true;
                        SceneManager.LoadScene("MainMenu");
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
            if (gameOverUI != null)
            {
                gameOverUI.SetActive(true);
            }
            Time.timeScale = 0f;
        }
    }

    public void ResetGame()
    {
        playerLives = 3;
        playerScore = 0;
        hasAdvanced = false;

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
            Debug.Log("Mensaje desactiva UI");
        }

        Time.timeScale = 1f;
    }
}

