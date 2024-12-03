using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public float speed = 5f;  // Speed of the asteroid's movement
    public float rotationSpeed = 30f;  // Rotation speed of the asteroid
    public GameObject[] smallerAsteroids;  // Prefabs for splitting into smaller asteroids
    public float splitTime = 1f;  // Delay before the asteroid splits

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Add random velocity to simulate random movement direction
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.linearVelocity = randomDirection * speed;

        // Add rotation to the asteroid for visual effect
        transform.Rotate(0f, 0f, Random.Range(0f, 360f));
    }

    void Update()
    {
        // Rotate asteroid constantly for effect
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    public void Split()
    {
        // Split the asteroid into smaller asteroids
        if (smallerAsteroids.Length > 0)
        {
            foreach (var asteroidPrefab in smallerAsteroids)
            {
                Instantiate(asteroidPrefab, transform.position, Quaternion.identity);
            }
        }

        // Destroy the current asteroid
        Destroy(gameObject);
    }
}
