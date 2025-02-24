using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI progressText;
    
    public void LoadScene(int levelIndex)
    {

        loadingScreen.SetActive(true);

        StartCoroutine(LoadSceneAsynchronously(levelIndex));
    }

    IEnumerator LoadSceneAsynchronously(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        operation.allowSceneActivation = false;

        float startTime = Time.time;
        float simulatedProgress = 0f; 

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            simulatedProgress = Mathf.MoveTowards(simulatedProgress, progress, Time.deltaTime * 0.5f);

            slider.value = simulatedProgress;

            progressText.text = (simulatedProgress * 100f).ToString("F0") + "%"; 

            if (simulatedProgress >= 1f && Time.time - startTime >= 1f)
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
    
}
