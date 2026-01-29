using UnityEngine;
using UnityEngine.Video;
using TMPro; // Nếu dùng TextMeshPro

public class VideoCo : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public GameObject endUI; // Kéo EndText vào đây

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        // Event prepareCompleted: Khi preload xong
        videoPlayer.prepareCompleted += OnPrepareCompleted;

        // Event loopPointReached: Khi video end (không loop)
        videoPlayer.loopPointReached += OnLoopPointReached;

        videoPlayer.loopPointReached += vp => Debug.Log("Loop point reached!");

        // Preload video
        videoPlayer.Prepare();
        Debug.Log("Preparing video...");
    }

    void OnPrepareCompleted(VideoPlayer vp)
    {
        Debug.Log("Video prepared! Press V to play.");
        // Optional: Tự play sau prepare
        // vp.Play();
    }

    void OnLoopPointReached(VideoPlayer vp)
    {
        Debug.Log("Video ended! Triggering end action.");
        if (endUI != null)
        {
            endUI.SetActive(true);
        }
        // Optional: Chuyển scene thay UI
        // UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
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
                Debug.LogWarning("Video not prepared yet.");
            }
        }

        // Optional: Stop bằng S
        if (Input.GetKeyDown(KeyCode.S))
        {
            videoPlayer.Stop();
            Debug.Log("Video stopped.");
        }
    }
}