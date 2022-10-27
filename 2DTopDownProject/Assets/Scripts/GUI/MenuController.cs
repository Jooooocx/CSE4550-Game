using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string MainMenu;
    public GameObject pauseMenu;
    public bool isPaused;

    // Use this for intitialization

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) // brings up pause menu if escape is pressed
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                //turn on pause menu if not on
                isPaused = true;
                pauseMenu.SetActive(true);
                //stop time
                Time.timeScale = 0f;
            }
        }
        
    }


    public void ReturnToMain()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Qutting");
    }
}
