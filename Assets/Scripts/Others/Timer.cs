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
    public GameObject WinPanel;

    [SerializeField] private Slider timerSlider;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float initialGameTime; 
    [SerializeField] private int level;

    private float gameTime; 
    private bool stopTimer;


    private void Awake()
    {
        Application.targetFrameRate = 60;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        controller = FindObjectOfType<Controller>();
        ResetTimer(); 
    }

    void Update()
    {
        if (!stopTimer)
        {
            gameTime -= Time.deltaTime; 

            if (gameTime <= 0)
            {
                stopTimer = true;
                GameWin();
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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Collider2D>().enabled = false;
        
        WinPanel.SetActive(true);

        UnlockNewLevel();
    }

    public void ResetTimer()
    {
        stopTimer = false; 
        gameTime = initialGameTime; 
        timerSlider.maxValue = initialGameTime;
        timerSlider.value = initialGameTime; 
        UpdateTimerDisplay(); 
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
        int currentUnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1); 
        if (level > currentUnlockedLevel) 
        {
            PlayerPrefs.SetInt("UnlockedLevel", level); 
            PlayerPrefs.Save(); 
        }
    }
}