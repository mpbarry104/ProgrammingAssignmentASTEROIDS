using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public AudioClip shootSound;
    private AudioSource shootingAudioSource;

    void Start()
    {
        shootingAudioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//space makes you shoot
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);//make the bullet
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.up * projectileSpeed;
        }
        if (shootingAudioSource != null && shootSound != null)
        {
            shootingAudioSource.PlayOneShot(shootSound);
        }
    }
}
