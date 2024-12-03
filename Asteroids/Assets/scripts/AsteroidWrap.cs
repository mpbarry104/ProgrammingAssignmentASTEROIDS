using UnityEngine;

public class AsteroidWrap : MonoBehaviour
{
    private Camera mainCamera;
    private float screenWidth;
    private float screenHeight;

    void Start()
    {
        // Cache the main camera
        mainCamera = Camera.main;

        // Calculate the screen width and height in world units
        screenHeight = mainCamera.orthographicSize; // Half the height of the screen
        screenWidth = screenHeight * mainCamera.aspect; // Width depends on aspect ratio
    }

    void Update()
    {
        WrapAroundScreen();
    }

    private void WrapAroundScreen()
    {
        Vector3 position = transform.position;

        // Check horizontal wrapping
        if (position.x > screenWidth)
            position.x = -screenWidth;
        else if (position.x < -screenWidth)
            position.x = screenWidth;

        // Check vertical wrapping
        if (position.y > screenHeight)
            position.y = -screenHeight;
        else if (position.y < -screenHeight)
            position.y = screenHeight;

        // Apply the new position
        transform.position = position;
    }
}
