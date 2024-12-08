using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); //show menu
        Time.timeScale = 0f; //pause time
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); //hide meny
        Time.timeScale = 1f; //start time
        isPaused = false;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // Resume time
        SceneManager.LoadScene("Start");
    }
}

