using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject how2play;
    public GameObject backbtn;
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene("MVP");

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void HowToPlay()
    {
        // Open how to play screen
        how2play.SetActive(true);
        backbtn.SetActive(true);

    }

    public void QuitGame()
    {
        // Quit the game (works only in built executable, not in Unity Editor)
        Application.Quit();
    }

    public void Back()
    {
        how2play.SetActive(false);
        backbtn.SetActive(false);
    }

}