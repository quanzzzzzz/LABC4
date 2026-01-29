
using UnityEngine;

public class Sound : MonoBehaviour
{
private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Đảm bảo đang play
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void Update()
    {
        // Phím Q: Toggle giữa 2D (0) và 3D (1)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            audioSource.spatialBlend = (audioSource.spatialBlend == 0f) ? 1f : 0f;
            string mode = (audioSource.spatialBlend == 0f) ? "2D" : "3D";
            Debug.Log("Switched to " + mode + " Spatial Blend: " + audioSource.spatialBlend);
        }

        // Phím R: Restart sound (nếu cần)
        if (Input.GetKeyDown(KeyCode.R))
        {
            audioSource.Stop();
            audioSource.Play();
            Debug.Log("Sound restarted!");
        }
    }
}
