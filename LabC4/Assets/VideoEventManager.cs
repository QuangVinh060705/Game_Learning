using UnityEngine;
using UnityEngine.Video; // Thư viện bắt buộc để làm việc với Video
using UnityEngine.UI;    // Thư viện để điều khiển UI

public class VideoEventManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Kéo VideoPlayerObj vào đây
    public GameObject endUI;       // Kéo EndGamePanel vào đây

    void Start()
    {
        // Kiểm tra nếu chưa gán thì tự tìm
        if (videoPlayer == null) videoPlayer = GetComponent<VideoPlayer>();

        // Đăng ký sự kiện: Khi video chạy hết (loopPointReached)
        videoPlayer.loopPointReached += OnVideoFinished;

        // Đăng ký sự kiện: Khi video đã chuẩn bị xong (prepareCompleted) - optional
        videoPlayer.prepareCompleted += OnVideoReady;
    }

    void OnVideoReady(VideoPlayer source)
    {
        Debug.Log("Video đã sẵn sàng để phát!");
    }

    void OnVideoFinished(VideoPlayer source)
    {
        Debug.Log("Video đã chạy xong!");
        
        // Hiện bảng UI đã chuẩn bị ở Bước 1
        if (endUI != null)
        {
            endUI.SetActive(true);
        }
    }

    // Hàm để gán vào nút "Chơi lại" trên UI
    public void ReplayVideo()
    {
        endUI.SetActive(false); // Ẩn UI đi
        videoPlayer.Play();     // Phát lại từ đầu
    }
}