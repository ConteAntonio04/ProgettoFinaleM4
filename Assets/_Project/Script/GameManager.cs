using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Timer Settings")]
    [SerializeField]
    private float levelTime = 120f;
    public TextMeshProUGUI timerText;
    private float currentTime;

    [Header("Score Settings")]
    [SerializeField]    
    private int winScore = 200;
    public TextMeshProUGUI scoreText;
    private int score = 0;

    [Header("UI Panels")]
    public GameObject winUI;
    public GameObject loseUI;

    private bool gameEnded = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentTime = levelTime;
        Time.timeScale = 1f;

        if (winUI != null) winUI.SetActive(false);
        if (loseUI != null) loseUI.SetActive(false);

        UpdateScoreUI();
        UpdateTimerUI();
    }

    void Update()
    {
        if (gameEnded) return;

        UpdateTimer();
    }

    void UpdateTimer()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            LoseGame();
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        if (timerText != null)
            timerText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddTime(float amount)
    {
        if (gameEnded) return;

        currentTime += amount;
        UpdateTimerUI();
    }

    public void AddPoints(int amount)
    {
        if (gameEnded) return;

        score += amount;
        score = Mathf.Clamp(score, 0, winScore);
        UpdateScoreUI();

        if (score >= winScore)
        {
            WinGame();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score + " / " + winScore;
    }

    
    public void WinGame()
    {
        if (gameEnded) return;

        gameEnded = true;
        if (winUI != null) winUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoseGame()
    {
        if (gameEnded) return;

        gameEnded = true;
        if (loseUI != null) loseUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

   
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
