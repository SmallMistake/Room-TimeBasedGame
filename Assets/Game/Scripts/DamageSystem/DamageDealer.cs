using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageOnTouch;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        I_Hurtable hurtable = collision.GetComponent<I_Hurtable>();
        if (hurtable != null)
        {
            hurtable.Damage(damageOnTouch);
        }
    }
}
