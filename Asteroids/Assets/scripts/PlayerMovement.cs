using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float TP = 5f; //thrust power (Forward)
    public float RS = 200f; //rotate speed
    public float MS = 10f; //max speed

    private Rigidbody2D rb;
    public AudioClip thrustSound;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found on this GameObject.");
        }
        else
        {
            audioSource.loop = true;//makes sound loop
        }
    }

    [System.Obsolete]
    void Update()
    {
        float rotationInput = -Input.GetAxis("Horizontal"); // Use left/right arrows or A/D
        transform.Rotate(Vector3.forward * rotationInput * RS * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) // Use up arrow or W for thrust
        {
            Vector2 thrust = transform.up * TP;
            rb.AddForce(thrust);

            if (!audioSource.isPlaying && thrustSound != null)
            {
                audioSource.clip = thrustSound;
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        if (rb.velocity.magnitude > MS)//limit max speed
        {
            rb.velocity = rb.velocity.normalized * MS;
        }
    }
    [System.Obsolete]
    void FixedUpdate()//this simulates drag
    {
        rb.velocity *= 0.99f;
    }
}
