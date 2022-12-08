using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "FightDialouge", menuName = "RPG/Dialouge/FightDialouge", order = 1)]
public class FightDialougeTemplate : ScriptableObject
{
    public string dialougeName;
    public List<string> statements;
}
