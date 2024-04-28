using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StatisticsManagement : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text deathCounterText;

    private float startTime;
    private bool isRunning;
    private int numberOfDeaths;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            StartTimer();
        }
    }

    private void Update()
    {
        if (isRunning)
        {
            float elapsedTime = Time.time - startTime;
            UpdateTimerText(elapsedTime);
        }
    }

    public void ResetGame()
    {
        numberOfDeaths = 0;
        isRunning = false;
    }

    public void PlayerDied()
    {
        numberOfDeaths++;
        UpdateDeathCounterText();
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    private void UpdateTimerText(float elapsedTime)
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = "Time: " + timerString;
    }

    private void UpdateDeathCounterText()
    {
        deathCounterText.text = "Deaths: " + numberOfDeaths;
    }
}
