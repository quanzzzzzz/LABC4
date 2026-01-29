using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                Debug.Log("Playing sound!");
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                Debug.Log("Stopping sound!");
            }
        }
    }
}