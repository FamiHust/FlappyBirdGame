using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu2 : MonoBehaviour
{
    public GameObject PausePanel;
    
    public void Pause()
    {
        PausePanel.SetActive(true);
    }

    public void Resume()
    {
        PausePanel.SetActive(false);
    }
}
