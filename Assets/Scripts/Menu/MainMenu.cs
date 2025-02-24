using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioManager audioManager;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioManager.PlayVFX(audioManager.wingClip);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
