using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject gameOverPanel;

    void OnEnable()
    {
        playerHealth.OnPlayerDied += ShowGameOver;
    }

    void OnDisable()
    {
        playerHealth.OnPlayerDied -= ShowGameOver;
    }

    void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Debug.Log("GAME OVER");
    }
}
