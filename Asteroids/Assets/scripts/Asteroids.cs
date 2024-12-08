using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public float speed = 5f;  //asteroid speed
    public float rotationSpeed = 30f;//rotation speed self explanatory
    public GameObject[] smallerAsteroids;//array holds smaller asteroids
    public float splitTime = 1f;//delay befor spli (dont think its used rn)
    private Rigidbody2D rb;//rigidbody for physics
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 randomDirection = Random.insideUnitCircle.normalized;//choose a random direction in unitcircle to move
        rb.linearVelocity = randomDirection * speed;//random direction times speed
        transform.Rotate(0f, 0f, Random.Range(0f, 360f));//radomly rotate sprite (it looks nicer)
    }
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);//keeps it spinning while flying
    }
    public void Split()//called when it needs to split
    {
        if (smallerAsteroids.Length > 0)
        {
            foreach (var asteroidPrefab in smallerAsteroids)//recreates small asteroid at same position
            {
                Instantiate(asteroidPrefab, transform.position, Quaternion.identity);
            }
        }
        Destroy(gameObject);//when smaller one is made big one is destroyed
    }
}
