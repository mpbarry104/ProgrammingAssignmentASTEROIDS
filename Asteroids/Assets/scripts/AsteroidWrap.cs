using UnityEngine;

public class AsteroidWrap : MonoBehaviour
{
    private Camera mainCamera;
    private float screenWidth;
    private float screenHeight;

    void Start()
    {
        mainCamera = Camera.main;
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
//horizontal
        if (position.x > screenWidth)
            position.x = -screenWidth;
        else if (position.x < -screenWidth)
            position.x = screenWidth;

//vertical
        if (position.y > screenHeight)
            position.y = -screenHeight;
        else if (position.y < -screenHeight)
            position.y = screenHeight;

 //spawn at other side
        transform.position = position;
    }
}
