using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private Controller controller;
    private AudioManager audioManager;

    [SerializeField] private Slider timerSlider;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float initialGameTime; // Thời gian ban đầu
    private float gameTime; // Thời gian hiện tại
    [SerializeField] private int level;

    public GameObject WinPanel;
    private bool stopTimer;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        controller = FindObjectOfType<Controller>();
        ResetTimer(); // Khởi tạo timer
    }

    void Update()
    {
        if (!stopTimer)
        {
            gameTime -= Time.deltaTime; // Giảm thời gian theo frame

            if (gameTime <= 0)
            {
                stopTimer = true;
                GameWin();
                //Time.timeScale = 0; // Dừng thời gian khi thắng
            }
            else
            {
                UpdateTimerDisplay();
            }
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(gameTime / 60f);
        int seconds = Mathf.FloorToInt(gameTime % 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerText.text = textTime;
        timerSlider.value = gameTime;
    }

    public void GameWin()
    {
        audioManager.PlayVFX(audioManager.winClip);

        // Ẩn menu game over nếu nó đang hiển thị
        if (controller != null)
        {
            controller.gameOverObj.SetActive(false); // Ẩn game over menu
        }
        WinPanel.SetActive(true);

        UnlockNewLevel();
    }

    public void ResetTimer()
    {
        stopTimer = false; // Đặt lại trạng thái stopTimer
        gameTime = initialGameTime; // Đặt lại thời gian về giá trị ban đầu
        timerSlider.maxValue = initialGameTime; // Đặt lại giá trị tối đa cho slider
        timerSlider.value = initialGameTime; // Đặt lại giá trị slider về thời gian ban đầu
        UpdateTimerDisplay(); // Cập nhật hiển thị timer
    }

    public void NextLevelMenu()
    {
        SceneManager.LoadScene("level_" + level.ToString());
    }


    public void StopTimer()
    {
        stopTimer = true;
    }

    void UnlockNewLevel()
    {
        int currentUnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1); // Lấy số level đã mở khóa
        if (level > currentUnlockedLevel) // Nếu level hiện tại lớn hơn level đã mở khóa
        {
            PlayerPrefs.SetInt("UnlockedLevel", level); // Cập nhật số level đã mở khóa
            PlayerPrefs.Save(); // Lưu thay đổi
        }
    }
}