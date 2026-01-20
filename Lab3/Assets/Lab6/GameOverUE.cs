using UnityEngine;

public class GameOverUE : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Debug.Log("GAME OVER (UnityEvent)");
    }
}
