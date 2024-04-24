using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatisticsManagement : MonoBehaviour
{
    // private float startTime;
    private int numberOfDeaths;
    // public Text timerText;
    // public Text deathCounterText;

    private void Start()
    {
        // startTime = PlayerPrefs.GetFloat("StartTime", 0f);
        numberOfDeaths = PlayerPrefs.GetInt("NumberOfDeaths", 0);

        // UpdateTimerText();
        // UpdateDeathCounterText();
    }

    private void Update()
    {
        // if (startTime > 0f)
        // {
        //     float elapsedTime = Time.realtimeSinceStartup - startTime;
        //     UpdateTimerText(elapsedTime);
        //     Debug.Log(elapsedTime);
        // }
        Debug.Log(numberOfDeaths);

    }

    public void ResetGame()
    {
        // startTime = Time.realtimeSinceStartup;
        numberOfDeaths = 0;

        // PlayerPrefs.SetFloat("StartTime", startTime);
        PlayerPrefs.SetInt("NumberOfDeaths", numberOfDeaths);

        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayerDied()
    {
        numberOfDeaths++;

        // UpdateDeathCounterText();
    }

    // private void UpdateTimerText(float elapsedTime = 0f)
    // {
    // float totalSeconds = elapsedTime > 0f ? elapsedTime : Time.realtimeSinceStartup - startTime;
    // int minutes = Mathf.FloorToInt(totalSeconds / 60f);
    // int seconds = Mathf.FloorToInt(totalSeconds % 60f);
    // string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
    // timerText.text = "Time: " + timerString;
    // }

    // private void UpdateDeathCounterText()
    // {
    //     deathCounterText.text = "Deaths: " + numberOfDeaths;
    // }

    // internal static void PlayerDie()
    // {
    //     throw new NotImplementedException();
    // }
}
