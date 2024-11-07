using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    
    
    [SerializeField] private int level;
    public void OpenLevel()
    {
        int unlockedLevels = PlayerPrefs.GetInt("UnlockedLevel", 1); // Lấy số level đã mở khóa
        if (level <= unlockedLevels) // Kiểm tra nếu level đã mở khóa
        {
            SceneManager.LoadScene("Level_" + level.ToString());
        }
        else
        {
            Debug.Log("Level " + level + " chưa được mở khóa.");
        }
    }
}
