using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene("MVP");
    }

    public void HowToPlay()
    {
        // Open how to play screen
    }

    public void QuitGame()
    {
        // Quit the game (works only in built executable, not in Unity Editor)
        Application.Quit();
    }
}