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
            Destroy(gameObject);
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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Escena cargada: " + scene.name);

        // 🧹 Eliminar HUDs duplicados si los hay
        GameObject[] huds = GameObject.FindGameObjectsWithTag("HUD");
        if (huds.Length > 1)
        {
            for (int i = 1; i < huds.Length; i++)
            {
                Destroy(huds[i]);
            }
        }

        // 🔁 Reconectar HUD actual
        GameObject hudCanvas = GameObject.FindWithTag("HUD");
        if (hudCanvas != null)
        {
            var hud = hudCanvas.GetComponent<HUDController>();
            if (hud != null)
            {
                Debug.Log("HUDController encontrado, forzando actualización");
                hud.ForceUpdate();
            }
            else
            {
                Debug.LogWarning("HUDController no encontrado en HUDCanvas.");
            }
        }
        else
        {
            Debug.LogWarning("HUDCanvas no encontrado en " + scene.name);
        }

        // 🎯 Reinicia hasAdvanced si entras a Nivel2
        if (scene.name == "Nivel2")
        {
            hasAdvanced = false;
        }

        // Reasignar GameOverUI
        GameObject ui = GameObject.Find("GameOverUI");
        if (ui != null)
        {
            Debug.Log("GameOverUI encontrado");
            gameOverUI = ui;
            gameOverUI.SetActive(false);
        }
        else
        {
            Debug.LogWarning("GameOverUI NO encontrado en " + scene.name);
        }
    }

    void Update()
    {
        string scene = SceneManager.GetActiveScene().name;

        switch (scene)
        {
            case "Nivel1":
                if (!hasAdvanced && playerScore >= 100)
                {
                    hasAdvanced = true;
                    SceneManager.LoadScene("Nivel2");
                    playerScore = 0;
                    playerLives = 3;
                }
                break;

            case "Nivel2":
                if (!hasAdvanced && playerScore >= 200)
                {
                    hasAdvanced = true;
                    SceneManager.LoadScene("FinPartida");
                }
                break;
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
            Debug.Log("Se activa el GameOverUI en escena: " + SceneManager.GetActiveScene().name);

            if (gameOverUI != null)
            {
                gameOverUI.SetActive(true);
            }
            else
            {
                Debug.LogWarning("gameOverUI es null en " + SceneManager.GetActiveScene().name);
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
