using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    public List<EnemyMoveSet> phases;

    private int currentPhaseIndex;
    private EnemyMoveSet currentPhase;
    private int currentMoveSetRange; //This is used for picking the enemies move. If the enemy has two moves one weighted 1 and another 5. This will be 6 and when the enemy moves a random number will be chosen out of 6 to determine the move.

    public Animator animator;

    private RPGEnemyHealthController healthController;

    private void Start()
    {
        healthController = gameObject.GetComponent<RPGEnemyHealthController>();
        currentPhaseIndex = -1;
        moveToNextPhase();
    }

    public EnemyMove GetAction()
    {
        EnemyMove move = pickAction();
        return move;
    }

    private EnemyMove pickAction()
    {
        List<EnemyMove> enemyMoves = currentPhase.moves;
        int chosenMoveIndex = Random.Range(0, currentMoveSetRange);

        foreach (EnemyMove move in enemyMoves)
        {
            chosenMoveIndex -= move.chanceOfHappeningWeight;
            if(chosenMoveIndex < 0)
            {
                animator.SetTrigger(move.attackAnimationName);
                return move;
            }
        }
        return null;
    }

    private void moveToNextPhase()
    {
        currentPhaseIndex++;
        currentPhase = phases[currentPhaseIndex];

        currentMoveSetRange = 0;

        List<EnemyMove> enemyMoves = currentPhase.moves;

        foreach (EnemyMove move in enemyMoves)
        {
            currentMoveSetRange += move.chanceOfHappeningWeight;
        }
    }

    public void Hurt(int damageAmount)
    {
        healthController.Hurt(damageAmount);
    }
}
