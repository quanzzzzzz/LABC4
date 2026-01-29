using UnityEngine;

public class GlobalAudioControl : MonoBehaviour
{
    private bool isMuted = false;
    private bool isPaused = false;

    void Update()
    {
        // Phím M: Mute / Unmute toàn bộ (volume 0 hoặc 1)
        if (Input.GetKeyDown(KeyCode.M))
        {
            isMuted = !isMuted;
            AudioListener.volume = isMuted ? 0f : 1f;
            Debug.Log("Audio " + (isMuted ? "MUTED" : "UNMUTED") + " | Volume: " + AudioListener.volume);
        }

        // Phím P: Pause / Resume toàn bộ
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            AudioListener.pause = isPaused;
            Debug.Log("Audio " + (isPaused ? "PAUSED" : "RESUMED") + " | Pause: " + AudioListener.pause);
        }
    }
}