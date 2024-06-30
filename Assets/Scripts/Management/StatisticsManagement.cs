using UnityEngine;
using TMPro;
public class StatisticsManagement : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text deathCounterText;
    public GameObject statisticsBOX;
    public float startTime;
    public string timerString;
    private bool isRunning;
    public int numberOfDeaths;

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
        UpdateDeathCounterText();
        startTime = Time.time;
        isRunning = false;
        UpdateTimerText(0);
    }

    public void PlayerDied()
    {
        numberOfDeaths++;
        UpdateDeathCounterText();
    }

    public void DisplayTrue()
    {
        statisticsBOX.SetActive(true);
    }

    public void DisplayFalse()
    {
        statisticsBOX.SetActive(false);
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
        timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timerString;
    }

    private void UpdateDeathCounterText()
    {
        deathCounterText.text = numberOfDeaths.ToString();
    }
}
