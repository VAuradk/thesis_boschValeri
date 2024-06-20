using UnityEngine;
using UnityEngine.InputSystem;

public class LayoutManagement : MonoBehaviour
{
    public static LayoutManagement instance;
    public GameObject pauseMenu;
    public GameObject endScreenOnly;
    private bool isGamePaused = false;
    public StatisticsManagement gameStatistics;
    public SceneManagement sceneManagement;
    public GameObject mainMenu;
    public bool IsGamePaused => isGamePaused;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void OnMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            TogglePause();
        }
    }

    public void MainMenuTrue()
    {
        mainMenu.SetActive(true);
    }

    public void ManiMenuFalse()
    {
        mainMenu.SetActive(false);
    }

    public void EndScreenTrue()
    {
        endScreenOnly.SetActive(true);
    }

    public void EndScreenFalse()
    {
        endScreenOnly.SetActive(false);
    }

    private void TogglePause()
    {
        isGamePaused = !isGamePaused;
        Time.timeScale = isGamePaused ? 0f : 1f;

        if (pauseMenu != null)
        {
            pauseMenu.SetActive(isGamePaused);
        }
        else
        {
            Debug.LogError("PauseMenu is null. Check if other Scene have gameManager active");
        }
    }

    public void HomeSkip()
    {
        sceneManagement.LoadSpecificScene("mainMenu");
        gameStatistics.ResetGame();
    }

    public void Home()
    {
        sceneManagement.LoadSpecificScene("mainMenu");
        TogglePause();
        gameStatistics.ResetGame();
    }

    public void Resume()
    {
        TogglePause();
    }

    public void Restart()
    {
        TogglePause();
        sceneManagement.Restart();
    }
}
