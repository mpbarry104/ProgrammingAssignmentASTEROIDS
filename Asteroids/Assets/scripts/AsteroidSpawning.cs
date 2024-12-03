using UnityEngine;

public class AsteroidSpawning : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRate = 2f;  // Spawn new asteroid every 2 seconds
    public float spawnDistance = 4f; // Distance to spawn asteroid from the player

    private float timeSinceLastSpawn;

    // Reference to the player
    public Transform playerTransform;

    void Start()
    {
        // Ensure the player reference is set in case it's missing
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindWithTag("Player").transform;
        }
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0f;
            SpawnAsteroid();
        }
    }

    void SpawnAsteroid()
    {
        // Get a random direction (unit vector)
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        // Calculate the spawn position 4 units away from the player
        Vector2 spawnPosition = (Vector2)playerTransform.position + randomDirection * spawnDistance;

        // Instantiate a new asteroid at the calculated position
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
    }
}
