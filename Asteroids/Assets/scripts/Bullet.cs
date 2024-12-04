using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet collides with an object tagged as "Asteroid"
        if (other.CompareTag("Asteroid"))
        {

            // Destroy the bullet upon collision
            Destroy(gameObject);

            // You can add additional logic to interact with the asteroid here (e.g., splitting it)
            Asteroids asteroid = other.GetComponent<Asteroids>();
            if (asteroid != null)
            {
                asteroid.Split();
            }
        }
    }
}
