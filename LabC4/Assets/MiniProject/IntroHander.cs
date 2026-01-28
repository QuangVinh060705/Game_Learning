using UnityEngine;
using UnityEngine.Video; // Cho Lab 5, 7
using UnityEngine.SceneManagement; // Để chuyển cảnh

public class IntroController : MonoBehaviour
{
    [Header("Cấu hình Component")]
    public VideoPlayer videoPlayer; // Kéo VideoPlayer vào đây
    public AudioSource audioSource; // Kéo AudioSource vào đây (Lab 1)

    private bool isPaused = false;

    void Start()
    {
        // LAB 7: Đăng ký sự kiện tự động gọi khi video chạy hết
        videoPlayer.loopPointReached += OnVideoEndReached;

        // LAB 1: Đảm bảo play từ đầu nếu cần
        videoPlayer.Play();
    }

    void Update()
    {
        // LAB 1: Nhấn Space để Play, S để Stop
        if (Input.GetKeyDown(KeyCode.Space)) videoPlayer.Play();
        if (Input.GetKeyDown(KeyCode.S)) videoPlayer.Stop();

        // LAB 3: Điều khiển âm thanh toàn cục (Mute)
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Nếu volume > 0 thì cho về 0, ngược lại cho về 1
            AudioListener.volume = AudioListener.volume > 0 ? 0 : 1;
            Debug.Log("Global Volume: " + AudioListener.volume);
        }

        // LAB 3: Pause/Resume toàn bộ bằng phím P
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                videoPlayer.Pause();
                Time.timeScale = 0; // Dừng mọi logic vật lý/gameplay
            }
            else
            {
                videoPlayer.Play();
                Time.timeScale = 1;
            }
        }
    }

    // --- XỬ LÝ KẾT THÚC VIDEO ---

    // Hàm này CHỈ dành cho VideoPlayer (không bị lỗi convert type)
    private void OnVideoEndReached(VideoPlayer source)
    {
        Debug.Log("Video chạy hết rồi!");
        GoToGameplay();
    }

    // Hàm này CHỈ dành cho Nút Skip (Gán vào OnClick của Button)
    public void SkipVideo()
    {
        Debug.Log("Đã nhấn nút Skip!");
        GoToGameplay();
    }

    private void GoToGameplay()
    {
        
        AudioListener.volume = 1; 

        Debug.Log("Đang vào Gameplay...");
      
    }
    private void LoadGameplayScene()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}