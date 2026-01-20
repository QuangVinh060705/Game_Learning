using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public TMP_Text hpText;

    void OnEnable()
    {
        playerHealth.OnHealthChanged += UpdateHP;
    }

    void OnDisable()
    {
        playerHealth.OnHealthChanged -= UpdateHP;
    }

    void UpdateHP(int hp)
    {
        hpText.text = "HP: " + hp;
    }
}
