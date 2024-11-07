using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    Timer timer;
    Character player;
    public static bool isGameOver;
    public static int numCoin;

    private static Controller instance;

    private AudioManager audioManager;
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject gameOverObj;
    public GameObject gameStartObj;
    public TextMeshProUGUI coinsText;
    [SerializeField] private int level;
    
    // [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    private int characterIndex;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        characterIndex = PlayerPrefs.GetInt("Index", 0);
        numCoin = PlayerPrefs.GetInt("NumCoin", 0);
        isGameOver = false;

        // DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        } 
        
    }

    void Start()
    {
        Time.timeScale = 0;
        player = Init.player;
        // Time.timeScale = 0;
        rb = GetComponent<Rigidbody2D>();


    }
    // Update is called once per frame
    void Update()
    {
        coinsText.text = "COIN : " + numCoin;
        player.Update();

        if (isGameOver)
        {
            gameOverObj.SetActive(true);
            Timer timer = FindObjectOfType<Timer>();
            if (timer != null)
            {
                timer.StopTimer(); // Gọi phương thức StopTimer để dừng timer
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            audioManager.PlayVFX(audioManager.wingClip);
            GameStart();
        }
        
    }

    // protected void FixedUpdate() 
    // {
    //     transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);    
    // }

    public static Controller GetInstance()
    {
        return instance;
    }

    public void GameStart()
    {
        gameStartObj.SetActive(false);
        Time.timeScale = 1;
    }

    public void resetGame()
    {
        // Gọi phương thức ResetTimer từ Timer
        Timer timer = FindObjectOfType<Timer>();
        if (timer != null)
        {
            timer.ResetTimer(); // Reset timer về giá trị ban đầu và bắt đầu lại
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void prevMenu()
    {
        SceneManager.LoadScene("level_" + level.ToString());
    }
    
    public void GameOver()
    {
        //gameOverObj.SetActive(true);
        audioManager.PlayVFX(audioManager.hitClip);
    }
    
    // public void OnCollisionEnter2D(Collision2D collision)
    // {
    //     player.GameOver();
    // }
}
