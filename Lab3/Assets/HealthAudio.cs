using UnityEngine;

public class HealthAudio : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public AudioSource hitSound;

    void OnEnable()
    {
        playerHealth.OnHealthChanged += PlaySound;
    }

    void OnDisable()
    {
        playerHealth.OnHealthChanged -= PlaySound;
    }

    void PlaySound(int hp)
    {
        hitSound.Play();
    }
}
