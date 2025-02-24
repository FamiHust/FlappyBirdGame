using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance {get; private set;}
    public int score;
    public TextMeshProUGUI currentScore;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentScore.text = score.ToString();
    }

    public void addScore()
    {
        score++;
        currentScore.text = score.ToString();
    }
}
