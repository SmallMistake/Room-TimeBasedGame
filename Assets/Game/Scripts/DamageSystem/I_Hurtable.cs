using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class I_Hurtable: MonoBehaviour
{
    public int startingHealth;
    internal int currentHealth;

    void Start()
    {
        currentHealth = startingHealth;
    }

    public abstract void Damage(int damageDealt);
}
