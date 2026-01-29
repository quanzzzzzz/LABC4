using UnityEngine;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        // Optional: Preload video để play nhanh hơn
        videoPlayer.Prepare();
        Debug.Log("Video prepared. Press V to play.");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (videoPlayer.isPrepared)
            {
                videoPlayer.Play();
                Debug.Log("Video playing!");
            }
            else
            {
                Debug.Log("Video not prepared yet.");
            }
        }

        // Optional: Phím S để Stop (test)
        if (Input.GetKeyDown(KeyCode.S))
        {
            videoPlayer.Stop();
            Debug.Log("Video stopped.");
        }
    }
}