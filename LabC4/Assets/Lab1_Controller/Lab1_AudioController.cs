using UnityEngine;

public class Lab1_AudioController : MonoBehaviour
{
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            audioSource.Stop();
        }
    }
}