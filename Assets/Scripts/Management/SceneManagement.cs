using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject endScreenOnly;
    private StatisticsManagement statisticsManagement;
    private LayoutManagement layoutManagement;

    private void Awake()
    {
        statisticsManagement = FindObjectOfType<StatisticsManagement>();
        layoutManagement = FindObjectOfType<LayoutManagement>();
    }

    public void NextScene()
    {
        // int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        // {
        //     SceneManager.LoadSceneAsync(nextSceneIndex);
        // }
        // else
        // {
        //     LoadSpecificScene("mainMenu");
        // }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Debug.Log("SceneManagement: Unsubscribed from sceneLoaded");
    }

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Debug.Log("SceneManagement: Subscribed to sceneLoaded");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1f;

        Debug.Log($"SceneManagement: Scene loaded: {scene.name}");

        if (scene.buildIndex == 1)
        {
            statisticsManagement.StartTimer();
        }

        if (scene.name == "mainMenu")
        {
            statisticsManagement.DisplayFalse();
            layoutManagement.EndScreenFalse();
            layoutManagement.MainMenuTrue();
        }

        else if (scene.name == "endScreen")
        {
            statisticsManagement.DisplayFalse();
            layoutManagement.EndScreenTrue();
        }

        else
        {
            statisticsManagement.DisplayTrue();
            layoutManagement.ManiMenuFalse();
        }
    }

    public void LoadSpecificScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        NextScene();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
