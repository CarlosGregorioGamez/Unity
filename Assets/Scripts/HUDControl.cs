using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        if (livesText == null)
            livesText = GameObject.Find("LivesText")?.GetComponent<TextMeshProUGUI>();

        if (scoreText == null)
            scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();

        ForceUpdate();
    }

    void Update()
    {
        if (GameManager.Instance != null && livesText != null && scoreText != null)
        {
            livesText.text = "Vidas restantes: " + Mathf.Max(0, GameManager.Instance.playerLives);
            scoreText.text = "Puntos: " + GameManager.Instance.playerScore;
        }
    }

    public void ForceUpdate()
    {
        if (GameManager.Instance != null && livesText != null && scoreText != null)
        {
            livesText.text = "Vidas restantes: " + Mathf.Max(0, GameManager.Instance.playerLives);
            scoreText.text = "Puntos: " + GameManager.Instance.playerScore;
        }
    }
}
