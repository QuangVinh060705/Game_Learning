using UnityEngine;

public class Lab3_GlobalAudio : MonoBehaviour
{
    bool isMuted = false;
    bool isPaused = false;

    void Update()
    {
        // MUTE / UNMUTE
        if (Input.GetKeyDown(KeyCode.M))
        {
            isMuted = !isMuted;
            AudioListener.volume = isMuted ? 0f : 1f;

            if (isMuted)
                Debug.Log("Audio MUTED");
            else
                Debug.Log("Audio UNMUTED");
        }

        // PAUSE / UNPAUSE
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            AudioListener.pause = isPaused;

            if (isPaused)
                Debug.Log("Audio PAUSED");
            else
                Debug.Log("Audio RESUMED");
        }
    }
}