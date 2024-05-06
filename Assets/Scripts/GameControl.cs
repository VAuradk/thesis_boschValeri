using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject pauseMenu;
    private bool isGamePaused = false;
    public StatisticsManagement gameStatistics;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log(gameObject.name);
            Destroy(gameObject);
        }
    }

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
        // GameObject eventSystem = GameObject.Find("EventSystem");
        // if (eventSystem != null)
        // {
        //     eventSystem.SetActive(false);
        // }

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