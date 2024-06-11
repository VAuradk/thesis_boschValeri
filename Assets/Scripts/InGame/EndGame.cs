using UnityEngine;

public class EndGame : MonoBehaviour
{
    private StatisticsManagement gameStatistics;

    private void Awake()
    {
        gameStatistics = FindAnyObjectByType<StatisticsManagement>();
    }

    private void Update()
    {
        Debug.Log("1 =" + gameStatistics.timerString);
        Debug.Log("2 = " + gameStatistics.numberOfDeaths);

        Time.timeScale = 0f;
    }


}