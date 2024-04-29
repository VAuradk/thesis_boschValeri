using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    // Método para pausar el juego
    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f; // Pausar el tiempo
    }

    // Método para ir al menú principal
    public void Home()
    {
        SceneManager.LoadScene("mainMenu");
        Time.timeScale = 1f; // Restaurar el tiempo
        pausePanel.SetActive(false);
    }

    // Método para reanudar el juego
    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f; // Restaurar el tiempo
    }

    // Método para reiniciar la escena actual
    public void Restart()
    {
        pausePanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // Restaurar el tiempo
    }
}
