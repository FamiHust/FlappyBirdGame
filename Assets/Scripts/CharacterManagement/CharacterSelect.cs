using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    private AudioManager audioManager;

    private int index;
    [SerializeField] private int playGame;

    public UnlockCharacter[] unlockCharacters;
    public Button unlockButton;
    public TextMeshProUGUI coinsText;

    [SerializeField] GameObject[] characters;
    [SerializeField] TextMeshProUGUI characterName;
    [SerializeField] GameObject[] characterPrefabs;
    public static GameObject selectedCharacter;

    private void Awake()
    {

        foreach (UnlockCharacter c in unlockCharacters)
        {
            if (c.price == 0)
                c.isUnlocked = true;
            else
            {
                c.isUnlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }
        }
        UpdateUI();

        Application.targetFrameRate = 60;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        SelectCharacter();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioManager.PlayVFX(audioManager.wingClip);
        }
    }

    public void OnPrevButtonClick()
    {
        if (index > 0)
        {
            index--;
        }
        SelectCharacter();
        if (unlockCharacters[index].isUnlocked)
            PlayerPrefs.SetInt("Index", index);
        UpdateUI();
    }

    public void OnNextButtonClick()
    {
        if (index < characters.Length - 1)
        {
            index++;
        }
        SelectCharacter();
        if (unlockCharacters[index].isUnlocked)
            PlayerPrefs.SetInt("Index", index);
        UpdateUI();
    }

    private void SelectCharacter()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (i == index)
            {
                characters[i].GetComponent<SpriteRenderer>().color = Color.white;
                selectedCharacter = characterPrefabs[i];
                characterName.text = characterPrefabs[i].name;
            }
            else
            {
                characters[i].GetComponent<SpriteRenderer>().color = Color.grey;
            }
        }
    }

    public void OnPlayButtonClick()
    {
        if (!unlockCharacters[index].isUnlocked)
        {
            return;
        }
        SceneManager.LoadScene("PlayGame_" + playGame.ToString());
    }

    public void HomeButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateUI()
    {
        coinsText.text = PlayerPrefs.GetInt("NumCoin", 0).ToString();
        if (unlockCharacters[index].isUnlocked == true)
            unlockButton.gameObject.SetActive(false);
        else
        {
            unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = "PRICE : " + unlockCharacters[index].price;
            if (PlayerPrefs.GetInt("NumCoin", 0) < unlockCharacters[index].price)
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = false;
            }
            else
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;
            }
        }
    }

    public void Unlock()
    {
        int coins = PlayerPrefs.GetInt("NumCoin", 0);
        int price = unlockCharacters[index].price;
        PlayerPrefs.SetInt("NumCoin", coins - price);
        PlayerPrefs.SetInt(unlockCharacters[index].name, 1);
        PlayerPrefs.SetInt("Index", index);
        unlockCharacters[index].isUnlocked = true;
        UpdateUI();

    }
}
