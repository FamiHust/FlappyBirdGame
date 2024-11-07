using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu3 : MonoBehaviour
{
    public GameObject PausePanel;
    
    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 0;
    }
}
