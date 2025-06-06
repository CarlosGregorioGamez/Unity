using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public GameObject mainMenuPanel;  
    public GameObject controlsPanel;


    void Start()
    {
        controlsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void Play()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame();
        }

        SceneManager.LoadScene("Nivel1");
    }


    public void Exit()
    {
        Application.Quit();
        Debug.Log("Cerrando el juego...");
    }

    public void VerControles()
    {
        mainMenuPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void Volver()
    {
        mainMenuPanel.SetActive(true);
        controlsPanel.SetActive(false);
    }
}
