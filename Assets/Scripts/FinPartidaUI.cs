using UnityEngine;
using UnityEngine.SceneManagement;

public class FinPartidaUI : MonoBehaviour
{
    public void VolverAlMenu()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame(); // reinicia vidas y puntos
        }

        SceneManager.LoadScene("MenuInicio");
    }
}
