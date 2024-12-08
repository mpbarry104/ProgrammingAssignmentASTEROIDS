using UnityEngine;

public class PlayerWrap : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 screenBounds;
    private float oW; // width
    private float oH; // height
    private AudioSource audioSource; // Reference to AudioSource
    public AudioClip wrapSound; // Sound to play when wrapping

    void Start()
    {
        mainCamera = Camera.main;
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            oW = renderer.bounds.extents.x; // Half-width
            oH = renderer.bounds.extents.y; // Half-height
        }

        // Add or get AudioSource component
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void LateUpdate()
    {
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        Vector3 newPosition = transform.position;

        bool playedSound = false; // Flag to check if sound has been played

        if (transform.position.x > screenBounds.x + oW) // Check X
        {
            newPosition.x = -screenBounds.x - oW;
            playedSound = true; // Set flag to true when wrapping
        }
        else if (transform.position.x < -screenBounds.x - oW)
        {
            newPosition.x = screenBounds.x + oW;
            playedSound = true; // Set flag to true when wrapping
        }

        if (transform.position.y > screenBounds.y + oH) // Check Y
        {
            newPosition.y = -screenBounds.y - oH;
            playedSound = true; // Set flag to true when wrapping
        }
        else if (transform.position.y < -screenBounds.y - oH)
        {
            newPosition.y = screenBounds.y + oH;
            playedSound = true; // Set flag to true when wrapping
        }

        if (playedSound && wrapSound != null)
        {
            audioSource.PlayOneShot(wrapSound); // Play the wrap sound if the player wraps and the sound is assigned
        }

        transform.position = newPosition;
    }
}
