using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "EnemyMoveSet", menuName = "RPG/EnemyMoveSet", order = 1)]
public class EnemyMoveSet : ScriptableObject
{
    public List<EnemyMove> moves;
}

[System.Serializable]
public class EnemyMove
{
    public string attackName;
    public int attackAmount;
    public string attackDialouge;
    public int chanceOfHappeningWeight;

    public string attackAnimationName;
}
