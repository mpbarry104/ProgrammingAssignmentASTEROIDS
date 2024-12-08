using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void StartGame()//function to start the game on title screen
    {
        SceneManager.LoadScene("Game");
    }
}
