using UnityEngine;

public class PlayerWrap : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 screenBounds;
    private float oW;//width
    private float oH;//height

    void Start()
    {
        mainCamera = Camera.main;
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            oW = renderer.bounds.extents.x; // Half-width
            oH = renderer.bounds.extents.y; // Half-height
        }
    }

    void LateUpdate()
    {
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        Vector3 newPosition = transform.position;
        if (transform.position.x > screenBounds.x + oW) //check X
        {
            newPosition.x = -screenBounds.x - oW;
        }
        else if (transform.position.x < -screenBounds.x - oW)
        {
            newPosition.x = screenBounds.x + oW;
        }
        if (transform.position.y > screenBounds.y + oH)//check y
        {
            newPosition.y = -screenBounds.y - oH;
        }
        else if (transform.position.y < -screenBounds.y - oH)
        {
            newPosition.y = screenBounds.y + oH;
        }
        transform.position = newPosition;
    }
}
