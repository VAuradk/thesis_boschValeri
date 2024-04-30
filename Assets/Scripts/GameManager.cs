using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isGamePaused = false;
    public StatisticsManagement gameStatistics;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindGameObjectWithTag("playerNormalMode");
    }

    public void OnMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            TogglePause();
        }
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

    public void Home()
    {
        SceneManager.LoadScene("mainMenu");
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
