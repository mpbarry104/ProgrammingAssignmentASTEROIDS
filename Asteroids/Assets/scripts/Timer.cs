using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timeElapsed = 0f; //life time
    private bool isGameOver = false; //game over stops time

    void Update()
    {
        if (!isGameOver)
        {
            timeElapsed += Time.deltaTime; //time goes forward
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60);//makes minutes
        int seconds = Mathf.FloorToInt(timeElapsed % 60);//makes seconds
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        isGameOver = true;
    }
}
