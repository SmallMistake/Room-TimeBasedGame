using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayController : MonoBehaviour
{
    public int currentIndex;
    Schedule schedule;
    private ScriptForDay currentDay;
    // Start is called before the first frame update
    void Start()
    {
        Timer.timerFinished += EndDay;
        schedule = Resources.Load<Schedule>("FullSchedule");
        currentDay = schedule.day[currentIndex];
    }

    public void EndDay()
    {
        print("TODO End Day");
    }

    private void OnDestroy()
    {
        Timer.timerFinished -= EndDay;
    }
}
