using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public int score;

    public TextMeshProUGUI currentScore;
    private TextMeshProUGUI highScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        currentScore.text = score.ToString();

        // highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        //UpdateHighScore();
    }

    // private void UpdateHighScore()
    // {
    //     if (score > PlayerPrefs.GetInt("HighScore"))
    //     {
    //         PlayerPrefs.SetInt("HighScore", score);
    //         highScore.text = score.ToString();
    //     }
    // }

    public void addScore()
    {
        score++;
        currentScore.text = score.ToString();
        //UpdateHighScore();
    }
}
