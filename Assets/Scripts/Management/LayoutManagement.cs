using UnityEngine;
using UnityEngine.InputSystem;

public class LayoutManagement : MonoBehaviour
{
    public static LayoutManagement instance;
    public GameObject pauseMenu;
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
        // else
        // {
        //     Debug.Log(gameObject.name);
        //     Destroy(gameObject);
        // }
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
