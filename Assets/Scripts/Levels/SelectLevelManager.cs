using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelManager : MonoBehaviour
{
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ListMenu()
    {
        SceneManager.LoadScene(3);
    }
}
