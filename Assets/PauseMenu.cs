using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Added namespace for SceneManager

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Hide the pause menu UI
        Time.timeScale = 1f;         // Resume game time
        GameIsPaused = false;        // Update the pause state
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Show the pause menu UI
        Time.timeScale = 0f;         // Freeze game time
        GameIsPaused = true;         // Update the pause state
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f; // Resume time before changing the scene
        SceneManager.LoadScene("Menu"); // Load the menu scene
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game..."); // Log the quit action
        Application.Quit(); // Quit the application
    }
}
