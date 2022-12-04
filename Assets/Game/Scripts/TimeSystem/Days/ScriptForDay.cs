using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "ScriptForDay", menuName = "TimeSystem/ScriptForDay", order = 1)]
public class ScriptForDay : ScriptableObject
{
    public string nameOfDay;
    public List<GameEvent> eventsForDay;
}
