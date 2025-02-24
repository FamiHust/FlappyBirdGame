using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    public GameObject[] locks;
    public GameObject levelButtons;

    private void Awake()
    {
        ButtonToArray();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        int maxLevels = buttons.Length;
        unlockedLevel = Mathf.Min(unlockedLevel, maxLevels);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            SetButtonAlpha(buttons[i], 0.5f); 
            locks[i].SetActive(true);
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
            SetButtonAlpha(buttons[i], 1f);
            locks[i].SetActive(false); 
        }
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("UnlockedLevel"))
        {
            PlayerPrefs.SetInt("UnlockedLevel", 1); 
            PlayerPrefs.Save(); 
        }
    }

    void ButtonToArray()
    {
        int childCount = levelButtons.transform.childCount;
        buttons = new Button[childCount];
        locks = new GameObject[childCount];

        for (int i = 0; i < childCount; i++)
        {
            buttons[i] = levelButtons.transform.GetChild(i).gameObject.GetComponent<Button>();
            locks[i] = levelButtons.transform.GetChild(i).Find("LockImage").gameObject; 
        }
    }

    void SetButtonAlpha(Button button, float alpha)
    {
        Color color = button.GetComponent<Image>().color;
        color.a = alpha;
        button.GetComponent<Image>().color = color;
    }
}
