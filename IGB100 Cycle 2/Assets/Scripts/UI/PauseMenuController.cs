using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    private void Start()
    {
        ResumeGame();
    }

    private void Update()
    {
        // Check for input to pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;  // Pause the game by setting the time scale to 0
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;  // Resume the game by setting the time scale back to 1
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main menu");
    }
}