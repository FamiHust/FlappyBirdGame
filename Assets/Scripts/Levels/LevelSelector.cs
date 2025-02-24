using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private int level;
    public void OpenLevel()
    {
        int unlockedLevels = PlayerPrefs.GetInt("UnlockedLevel", 1); 

        if (level <= unlockedLevels) 
        {
            SceneManager.LoadScene("Level_" + level.ToString());
        }
    }
}
