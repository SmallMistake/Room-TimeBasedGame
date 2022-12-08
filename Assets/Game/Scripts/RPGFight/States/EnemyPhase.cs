using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyPhase : MonoBehaviour, FightState
{
    public delegate void EnemyPhaseStart();
    public static EnemyPhaseStart startEnemyPhase;

    internal List<EnemyBrain> enemies;
    private FightManager fightManager;

    //public void StartState() { } //Dont use, use StartPhase

    public void StartPhase(List<EnemyBrain> enemies, FightManager fightManager)
    {
        this.fightManager = fightManager;
        this.enemies = enemies;
        startEnemyPhase.Invoke();
        StartCoroutine(HandleEnemyMoves());
    }

    IEnumerator HandleEnemyMoves()
    {
        if (enemies != null)
        {
            foreach (EnemyBrain enemy in enemies)
            {
                EnemyMove move = enemy.GetAction();
                yield return StartCoroutine(fightManager.PerformEnemyAction(move.attackDialouge, move.attackAmount));
            }
        }
        fightManager.moveToNextPhase();
    }
}
