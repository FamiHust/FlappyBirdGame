using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;
    public GameObject levelButtons;
    public GameObject[] locks;

    private void Awake()
    {
        ButtonToArray();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // Đảm bảo rằng unlockedLevel không vượt quá số lượng nút
        int maxLevels = buttons.Length;
        unlockedLevel = Mathf.Min(unlockedLevel, maxLevels);

        for (int i = 0; i < buttons.Length; i++)
        {
            // Đặt nút không tương tác và điều chỉnh độ mờ
            buttons[i].interactable = false;
            SetButtonAlpha(buttons[i], 0.5f); // Đặt độ mờ cho nút chưa mở khóa
            locks[i].SetActive(true);
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
            SetButtonAlpha(buttons[i], 1f); // Đặt độ mờ cho nút đã mở khóa
            locks[i].SetActive(false); // Ẩn khóa
        }
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("UnlockedLevel"))
        {
            PlayerPrefs.SetInt("UnlockedLevel", 1); // Mở khóa level đầu tiên
            PlayerPrefs.Save(); // Lưu thay đổi
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
            locks[i] = levelButtons.transform.GetChild(i).Find("LockImage").gameObject; // Tìm đối tượng khóa con
        }
        // Kiểm tra xem các mảng đã được khởi tạo đúng hay chưa
        Debug.Log($"Buttons Count: {buttons.Length}, Locks Count: {locks.Length}");
    }

    void SetButtonAlpha(Button button, float alpha)
    {
        Color color = button.GetComponent<Image>().color; // Lấy màu của nút
        color.a = alpha; // Thay đổi độ mờ
        button.GetComponent<Image>().color = color; // Cập nhật màu cho nút
    }
}
