using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ActionType { attack, heal }

[CreateAssetMenu(fileName = "RPGAction", menuName = "RPG/RPGAction", order = 1)]
public class RPGAction : ScriptableObject
{
    public RPGActionData actionData;
}

[System.Serializable]
public class RPGActionData
{
    public string actionName;
    public ActionType type;
    public int baseAmount;
    public string actionDescription;
    public string actionAnimation;
}
