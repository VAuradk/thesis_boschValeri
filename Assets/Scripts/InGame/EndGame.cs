using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    private StatisticsManagement gameStatistics;
    public TMP_Text finalTimer;
    public TMP_Text finalDeaths;

    public bool endScreen;

    private void Awake()
    {
        gameStatistics = FindAnyObjectByType<StatisticsManagement>();
    }

    private void Update()
    {
        finalTimer.text = gameStatistics.timerString;
        finalDeaths.text = "" + gameStatistics.numberOfDeaths;

        Time.timeScale = 0f;
    }

}