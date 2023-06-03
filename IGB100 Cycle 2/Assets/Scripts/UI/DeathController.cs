using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    public GameObject DeathUI;
    //private bool isDead = false;
    private float currentHealth;
    private void Start()
    {
    }

    private void Update()
    {
        currentHealth = SingletonParams.Instance.currentHealth;

        if (currentHealth <= 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        DeathUI.SetActive(true);
        //isDead = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame()
    {
        Time.timeScale = 1f; 
        DeathUI.SetActive(false);
        //isDead = false;
        SceneManager.LoadScene("MVP");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main menu");
    }
}