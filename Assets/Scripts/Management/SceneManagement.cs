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
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // public void LoadScene(string sceneName)
    // {
    //     SceneManager.LoadSceneAsync(sceneName);
    // }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
