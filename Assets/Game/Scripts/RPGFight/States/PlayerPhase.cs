using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPhase : FightState
{
    public delegate void PlayerPhaseStart();
    public static PlayerPhaseStart startPlayerPhase;

    public PlayerPhase()
    {
        StartPhase();
    }

    public void StartPhase()
    {
        startPlayerPhase.Invoke();
    }
}
