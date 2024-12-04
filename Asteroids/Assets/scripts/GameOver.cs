using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    public AudioClip collisionSound; // Assign the collision sound
    private AudioSource audioSource;
    private bool isDestroyed = false; // Prevent multiple collisions from triggering

    void Start()
    {
        // Get or add an AudioSource component
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") && !isDestroyed)
        {
            isDestroyed = true; // Prevent multiple triggers
            Debug.Log("Player hit! Playing sound and restarting...");

            // Play collision sound
            if (collisionSound != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }

            // Disable the player visually and functionally
            foreach (var renderer in GetComponentsInChildren<Renderer>())
            {
                renderer.enabled = false; // Hide visuals
            }
            foreach (var collider in GetComponents<Collider2D>())
            {
                collider.enabled = false; // Disable collision
            }

            // Restart the game after the sound finishes
            StartCoroutine(RestartGameAfterSound(collisionSound ? collisionSound.length : 0));
        }
    }

    IEnumerator RestartGameAfterSound(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for sound to finish
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart scene
    }
}
