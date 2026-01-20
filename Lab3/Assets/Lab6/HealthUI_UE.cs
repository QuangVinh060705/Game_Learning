using TMPro;
using UnityEngine;

public class HealthUI_UE : MonoBehaviour
{
    public TMP_Text healthText;

    public void UpdateHealth(int hp)
    {
        healthText.text = "HP: " + hp;
    }
}
