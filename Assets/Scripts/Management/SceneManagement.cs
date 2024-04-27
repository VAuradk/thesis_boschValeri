using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [HideInInspector] public TagManagement tagManager;
    public static SceneManagement instance;

    public virtual void Awake()
    {
        tagManager = FindObjectOfType<TagManagement>();

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

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
