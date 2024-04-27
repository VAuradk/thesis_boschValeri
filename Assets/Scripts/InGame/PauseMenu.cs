using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private bool isMenuActive = false;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home()
    {
        SceneManager.LoadScene("mainMenu");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void OnMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isMenuActive)
            {
                Resume(); // Call Resume if the menu is active
            }
            else
            {
                Pause(); // Call Pause if the menu is not active
            }
            isMenuActive = !isMenuActive; // Toggle the menu state
        }
    }
}
