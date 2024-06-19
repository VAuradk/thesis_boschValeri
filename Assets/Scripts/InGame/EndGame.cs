using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    private StatisticsManagement gameStatistics;
    public TMP_Text finalTimer;
    public TMP_Text finalDeaths;

    private bool theEND = false;

    private void Awake()
    {
        gameStatistics = FindObjectOfType<StatisticsManagement>();
    }

    private void Start()
    {
        theEND = true;
    }

    private void Update()
    {
        if (theEND == true)
        {
            finalTimer.text = "" + gameStatistics.timerString;
            finalDeaths.text = "" + gameStatistics.numberOfDeaths;

            theEND = false;
        }
    }

}