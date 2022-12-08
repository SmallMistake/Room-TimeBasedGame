using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RPGPlayerData : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;

    public PlayerHealthBarController playerHealthBarController;

    public FightManager fightManager;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void Hurt(int damage)
    {
        currentHealth -= damage;
        //Debug.Log($"PlayerHealth = {currentHealth}");
        if (currentHealth <= 0)
        {
            fightManager.HandlePlayerDeath();
        }
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float currentHealthPercent = (float) currentHealth / (float) maxHealth;
        playerHealthBarController.SetPlayerHealthVisual(currentHealthPercent);
    }
}
