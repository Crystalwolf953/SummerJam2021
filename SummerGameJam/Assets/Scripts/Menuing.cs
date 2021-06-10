using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuing : MonoBehaviour
{
    // For checking if the game is paused
    public static bool GameIsPaused = false;

    // Get all the UIs that need to be managed
    public GameObject pauseMenuUI;
    public GameObject gameOverlay;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Used to open the options ui or the inventory ui, but not both
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    #region PauseMenu
    // Resume the game from the pause menu
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameOverlay.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    // Pause the game to go into the pause menu
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameOverlay.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    // Load the main menu of the game
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainTitle");
    }

    // Quit the game
    public void QuitGame()
    {
        Debug.Log("Quiting game...");
        Application.Quit();
    }

    #endregion
}
