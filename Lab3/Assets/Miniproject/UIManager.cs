using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text hpText;
    public GameObject gameOverObject; // Kéo cái Panel vào đây

    void Start()
    {
        // Reset thời gian chạy lại bình thường mỗi khi vào game
        Time.timeScale = 1;
    }

    void OnEnable()
    {
        HealthSystem.OnPlayerHealthChanged += UpdateHP;
    }

    void OnDisable()
    {
        HealthSystem.OnPlayerHealthChanged -= UpdateHP;
    }

    void UpdateHP(int currentHealth)
    {
        hpText.text = "HP: " + currentHealth;

        if (currentHealth <= 0)
        {
            // Bật Panel lên (Text con sẽ hiện theo)
            gameOverObject.SetActive(true);
            Time.timeScale = 0; // Dừng game
        }
    }
}