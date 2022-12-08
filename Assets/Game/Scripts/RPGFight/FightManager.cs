using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Cinemachine;

public class FightManager : MonoBehaviour
{
    public delegate void InteractionOccured();
    public static InteractionOccured interactionOccured;

    public delegate void GameOver();
    public static GameOver gameOver;

    private FightState currentPhase;

    public GameObject enemyHolder;
    private List<EnemyBrain> enemies;

    public TextMeshProUGUI interactionText;
    public CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin cameraNoiseComponent;

    public DamageTextSpawner damageTextSpawner;

    public RPGPlayerData playerData;

    private void Start()
    {
        enemies = enemyHolder.GetComponentsInChildren<EnemyBrain>().ToList();
        currentPhase = new PlayerPhase();
        cameraNoiseComponent = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void giveUp()
    {
        print("TODO give up");
    }

    internal void useItem(RPGItemData itemData)
    {
        string actionDialouge = "Used " + itemData.name;
        StartCoroutine(PerformPlayerAction(actionDialouge));
    }

    internal void useAction(RPGActionData actionData)
    {
        string actionDialouge = "Used " + actionData.actionName;
        AttackEnemy(actionData);
        SpawnDamageText(actionData);
        StartCoroutine(PerformPlayerAction(actionDialouge));
    }

    private void AttackEnemy(RPGActionData actionData)
    {
        enemies[0].Hurt(actionData.baseAmount);
    }

    internal void moveToNextPhase()
    {
        //Debug.Log("Starting " + currentPhase.GetType().Name);
        switch (currentPhase)
        {
            case PlayerPhase nextPhase:
                EnemyPhase enemyPhase = gameObject.AddComponent<EnemyPhase>();
                currentPhase = enemyPhase;
                enemyPhase.StartPhase(enemies, this);

                break;
            case EnemyPhase nextPhase:
                ClearPhase(GetComponent<EnemyPhase>());
                PlayerPhase playerPhase = new PlayerPhase();
                currentPhase = playerPhase;
                break;
        }
    }

    private void ClearPhase(MonoBehaviour lastPhase) { 

        if(lastPhase != null)
        {
            Destroy(lastPhase);
        }
    }


    public IEnumerator PerformPlayerAction(string interactionDialouge)
    {
        interactionText.text = interactionDialouge;
        StartCoroutine(ShakeCamera());
        interactionOccured.Invoke();
        yield return new WaitForSeconds(1f);
        moveToNextPhase();
    }

    public IEnumerator PerformEnemyAction(string interactionDialouge, int damage)
    {
        interactionText.text = interactionDialouge;
        StartCoroutine(ShakeCamera());
        interactionOccured.Invoke();
        playerData.Hurt(damage);
       yield return new WaitForSeconds(1f);

    }

    public IEnumerator ShakeCamera()
    {
        cameraNoiseComponent.m_FrequencyGain = 1;
        yield return new WaitForSeconds(0.1f);
        cameraNoiseComponent.m_FrequencyGain = 0;

    }

    public void HandlePlayerDeath()
    {
        gameOver.Invoke();
    }

    private void SpawnDamageText(RPGActionData actionData)
    {
        if (actionData.type == ActionType.attack)
        {
            damageTextSpawner.SpawnDamageText(actionData.baseAmount.ToString());
        }
    }
}
