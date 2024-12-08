using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI highScoreText;
    private float timeElapsed = 0f; // Life time
    private bool isGameOver = false; // Game over stops time
    private float highScore = 0f;//highscore

    void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        UpdateHighScoreDisplay();
    }

    void Update()
    {
        if (!isGameOver)
        {
            timeElapsed += Time.deltaTime; // Time goes forward
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60); // Makes minutes
        int seconds = Mathf.FloorToInt(timeElapsed % 60); // Makes seconds
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        isGameOver = true;
        CheckForNewHighScore();//check if new high score
    }

    private void CheckForNewHighScore()
    {
        if (timeElapsed > highScore)
        {
            highScore = timeElapsed; // Update high score
            PlayerPrefs.SetFloat("HighScore", highScore); // Save high score
            PlayerPrefs.Save();
            UpdateHighScoreDisplay(); // Update the high score display
        }
    }

    private void UpdateHighScoreDisplay()
    {
        int highScoreMinutes = Mathf.FloorToInt(highScore / 60);
        int highScoreSeconds = Mathf.FloorToInt(highScore % 60);
        highScoreText.text = string.Format("High Score: {0:00}:{1:00}", highScoreMinutes, highScoreSeconds);
    }

    public float GetHighScore()
    {
        return highScore;
    }
}
