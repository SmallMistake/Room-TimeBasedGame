using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayController : MonoBehaviour
{
    private ProgressManager progressManager;
    Schedule schedule;
    private ScriptForDay currentDay;
    internal int currentIndex;
    // Start is called before the first frame update
    void Start()
    {
        progressManager = GameObject.FindGameObjectWithTag("SaveSystem").GetComponent<ProgressManager>();
        Timer.timerFinished += EndDay;
        schedule = Resources.Load<Schedule>("FullSchedule");
        currentDay = schedule.day[progressManager.cachedProgress.currentDay];
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
