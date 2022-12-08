using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGMenusController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject actionsMenu;
    public GameObject itemsMenu;
    public GameObject dialougeBorder;
    public GameObject enemyMenu;
    public GameObject currentMenu;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerPhase.startPlayerPhase += ShowPlayerMenus;
        EnemyPhase.startEnemyPhase += ShowInteractionMenus;
        FightManager.interactionOccured += ShowInteractionMenus;
        FightManager.gameOver += OnGameOver;
        ShowPlayerMenus();
    }

    private void OnDestroy()
    {
        PlayerPhase.startPlayerPhase -= ShowPlayerMenus;
        EnemyPhase.startEnemyPhase -= ShowInteractionMenus;
        FightManager.interactionOccured -= ShowInteractionMenus;
        FightManager.gameOver -= OnGameOver;
    }

    public void changeMenu(GameObject nextMenu)
    {
        currentMenu.SetActive(false);
        currentMenu = nextMenu;
        currentMenu.SetActive(true);
    }

    void ShowPlayerMenus()
    {
        mainMenu.SetActive(true);
        actionsMenu.SetActive(false);
        itemsMenu.SetActive(false);
        enemyMenu.SetActive(false);
        dialougeBorder.SetActive(true);
        currentMenu = mainMenu;
    }

    void ShowInteractionMenus()
    {
        mainMenu.SetActive(false);
        actionsMenu.SetActive(false);
        itemsMenu.SetActive(false);
        enemyMenu.SetActive(true);
        dialougeBorder.SetActive(false);
    }

    void OnGameOver()
    {
        Destroy(gameObject);
    }
}
