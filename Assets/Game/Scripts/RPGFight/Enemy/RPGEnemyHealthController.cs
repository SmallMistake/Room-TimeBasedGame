using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGEnemyHealthController : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    public List<int> phaseBarriers; //Once damage goes above barrier transition to next phase

    private int currentPhase = 0;

    public FightManager fightManager;
    public Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Hurt(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }

        for(int i = 0; i < phaseBarriers.Count; i++)
        {
            if(currentHealth <= phaseBarriers[i])
            {
                currentPhase = i + 1; //TODO improve this to quit once correct one is found
            }
        }
        Debug.Log("Current Enemy Health " + currentHealth);
        animator.SetInteger("CurrentPhase", currentPhase);

    }

    private void Die()
    {
        Debug.Log("TODO Enemy Death");
    }
}
