using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public AudioClip shootSound; // Assign your shooting sound clip here
    private AudioSource shootingAudioSource;

    void Start()
    {
        // Create a dedicated AudioSource for shooting
        shootingAudioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.up * projectileSpeed;
        }

        // Play the shoot sound
        if (shootingAudioSource != null && shootSound != null)
        {
            shootingAudioSource.PlayOneShot(shootSound);
        }
    }
}
