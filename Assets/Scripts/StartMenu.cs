using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    
    public void Play()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Cerrando el juego...");
    }
}
