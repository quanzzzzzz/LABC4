using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroCutscene : MonoBehaviour
{
    [Header("Video & Audio")]
    private VideoPlayer videoPlayer;
    private AudioSource bgmSource;

    [Header("UI")]
    public Button skipButton;

    [Header("Settings")]
    [SerializeField] private string gameplaySceneName = "Lab3"; // Tên scene gameplay (có thể chỉnh trong Inspector)

    void Start()
    {
        // Lấy component
        videoPlayer = GetComponent<VideoPlayer>();
        bgmSource = GetComponent<AudioSource>();

        if (videoPlayer == null)
        {
            Debug.LogError("Không tìm thấy VideoPlayer trên object này!");
            return;
        }

        if (bgmSource == null)
        {
            Debug.LogWarning("Không tìm thấy AudioSource cho BGM. Nhạc nền sẽ không phát.");
        }

        // Đăng ký event
        videoPlayer.prepareCompleted += OnVideoPrepared;
        videoPlayer.loopPointReached += OnVideoEnded;

        // Nút Skip
        if (skipButton != null)
        {
            skipButton.onClick.AddListener(OnSkipPressed);
        }
        else
        {
            Debug.LogError("Chưa gán SkipButton vào trường 'Skip Button' trong Inspector!");
        }

        // Preload video
        videoPlayer.Prepare();
        Debug.Log("Đang preload video intro...");

        // Phát BGM ngay lập tức nếu có
        if (bgmSource != null && bgmSource.clip != null)
        {
            bgmSource.Play();
            Debug.Log("BGM đang phát.");
        }
    }

    private void OnVideoPrepared(VideoPlayer vp)
    {
        Debug.Log("Video intro đã prepare xong! Bắt đầu phát tự động.");
        videoPlayer.Play();
    }

    private void OnVideoEnded(VideoPlayer vp)
    {
        Debug.Log($"Video intro kết thúc → Chuyển sang scene: {gameplaySceneName}");
        StopAllAudio();
        LoadGameplayScene();
    }

    private void OnSkipPressed()
    {
        Debug.Log($"Người chơi nhấn Skip → Chuyển sang scene: {gameplaySceneName}");
        StopAllAudio();
        LoadGameplayScene();
    }

    private void LoadGameplayScene()
    {
        if (string.IsNullOrEmpty(gameplaySceneName))
        {
            Debug.LogError("Tên scene Gameplay chưa được đặt! Vui lòng gán trong Inspector.");
            return;
        }

        try
        {
            SceneManager.LoadScene(gameplaySceneName);
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Không load được scene '{gameplaySceneName}'. Lỗi: {ex.Message}");
            Debug.LogError("Kiểm tra: Scene đã add vào Build Settings chưa?");
        }
    }

    private void StopAllAudio()
    {
        if (bgmSource != null && bgmSource.isPlaying)
        {
            bgmSource.Stop();
            Debug.Log("Đã stop BGM.");
        }

        if (videoPlayer != null && videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
            Debug.Log("Đã stop video.");
        }
    }

    void OnDestroy()
    {
        // Cleanup events
        if (videoPlayer != null)
        {
            videoPlayer.prepareCompleted -= OnVideoPrepared;
            videoPlayer.loopPointReached -= OnVideoEnded;
        }
    }
}