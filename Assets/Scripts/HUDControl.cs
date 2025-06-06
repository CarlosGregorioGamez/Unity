using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        if (GameManager.Instance != null)
        {
            int vidasAMostrar = Mathf.Max(0, GameManager.Instance.playerLives -1);
            livesText.text = "Vidas restantes: " + vidasAMostrar;
            scoreText.text = "Puntos: " + GameManager.Instance.playerScore;
        }
    }
}
