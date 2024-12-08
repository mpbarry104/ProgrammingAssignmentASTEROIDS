using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    public AudioClip collisionSound;
    private AudioSource audioSource;
    private bool isDestroyed = false;
    public GameObject gameOverMenuUI;
    private Timer timer;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        if (gameOverMenuUI != null)
        {
            gameOverMenuUI.SetActive(false);
        }
        timer = Object.FindFirstObjectByType<Timer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") && !isDestroyed)
        {
            isDestroyed = true;

            if (collisionSound != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }

            foreach (var renderer in GetComponentsInChildren<Renderer>())
            {
                renderer.enabled = false;//hides player
            }
            foreach (var collider in GetComponents<Collider2D>())
            {
                collider.enabled = false;//turn off player collision
            }

            StartCoroutine(ShowGameOverMenu(collisionSound ? collisionSound.length : 0));
        }
    }

    IEnumerator ShowGameOverMenu(float delay)
    {
        yield return new WaitForSeconds(delay);//make sure the sound stops
        if (gameOverMenuUI != null)
        {
            gameOverMenuUI.SetActive(true);//show the game over menu
        }

        if (timer != null)
        {
            timer.StopTimer();//stop timer
        }
    }
    public void RestartGame()//function to restart game
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ReturnToTitleScreen()//function to return to title screen
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }
}
