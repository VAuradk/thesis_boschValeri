using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    private StatisticsManagement gameStatistics;
    public TMP_Text finalTimer;
    public TMP_Text finalDeaths;

    private void Awake()
    {
        gameStatistics = FindObjectOfType<StatisticsManagement>();
    }

    private void Update()
    {
        finalTimer.text = "" + gameStatistics.timerString;
        finalDeaths.text = "" + gameStatistics.numberOfDeaths;

        Time.timeScale = 0f;
    }

}