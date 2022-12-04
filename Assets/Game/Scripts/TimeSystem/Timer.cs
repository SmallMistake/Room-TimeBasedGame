using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public delegate void TimerFinished();
    public static TimerFinished timerFinished;
    public TimeSection timeSection = new TimeSection();
    private float timeLeft;
    public TextMeshProUGUI timerText;


    void Start()
    {
        timeLeft = timeSection.lengthInSeconds;
    }

    private void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            timeLeft = 0;
            timerFinished.Invoke();
        }
        DisplayTime(timeLeft);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
            Debug.Log("Timer Has Ended");
        }
        if(timerText != null)
        {
            timerText.text = timeSection.convertToAMPM(timeToDisplay);
        }
    }
}
