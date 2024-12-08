using UnityEngine;

public class AsteroidSpawning : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRate = 2f;//Spawn new asteroid every 2 seconds
    public float spawnDistance = 4f;//Distance to spawn asteroid from the player

    private float timeSinceLastSpawn;
    public Transform playerTransform;

    void Start()
    {
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
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = (Vector2)playerTransform.position + randomDirection * spawnDistance;//finds spawn spot
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);//makes new asteroid at spot
    }
}
