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

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void OnMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            TogglePause();
        }
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
