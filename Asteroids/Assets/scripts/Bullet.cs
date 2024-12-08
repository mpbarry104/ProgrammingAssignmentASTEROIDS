using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Asteroid"))//if bullet hits asteroid
        {
            Destroy(gameObject);//bullet gone
            Asteroids asteroid = other.GetComponent<Asteroids>();
            if (asteroid != null)
            {
                asteroid.Split();
            }
        }
    }
}
