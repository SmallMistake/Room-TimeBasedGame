using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : I_Hurtable
{
    public override void Damage(int damageDealt)
    {
        currentHealth -= damageDealt;
        print(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
