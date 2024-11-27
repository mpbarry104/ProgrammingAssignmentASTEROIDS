using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float TP = 5f; //thrust power (Forward)
    public float RS = 200f; //rotate speed
    public float MS = 10f; //max speed

    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    [System.Obsolete]
    void Update()
    {
        // Handle rotation
        float rotationInput = -Input.GetAxis("Horizontal"); // Use left/right arrows or A/D
        transform.Rotate(Vector3.forward * rotationInput * RS * Time.deltaTime);

        // Handle thrust
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) // Use up arrow or W for thrust
        {
            Vector2 thrust = transform.up * TP;
            rb.AddForce(thrust);
        }

        // Limit maximum speed
        if (rb.velocity.magnitude > MS)
        {
            rb.velocity = rb.velocity.normalized * MS;
        }
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        // Apply drag to simulate friction (optional, tweak if needed)
        rb.velocity *= 0.99f;
    }
}
