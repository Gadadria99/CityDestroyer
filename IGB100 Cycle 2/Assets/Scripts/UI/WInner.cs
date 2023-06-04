using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WInner : MonoBehaviour
{
    public GameObject WinUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bonus()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene("Bonus");
        WinUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main menu");
    }
}
