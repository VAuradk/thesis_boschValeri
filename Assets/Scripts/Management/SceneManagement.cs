using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [HideInInspector] public TagManagement tagManager;

    public virtual void Awake()
    {
        tagManager = FindObjectOfType<TagManagement>();
    }

    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadSceneAsync(nextSceneIndex);
        }
        else
        {
            LoadSpecificScene("mainMenu");
        }
    }

    public void LoadSpecificScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
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
