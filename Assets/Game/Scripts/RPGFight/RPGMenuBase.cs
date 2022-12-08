using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGMenuBase : MonoBehaviour
{
    public FightManager fightManager;
    public FightDialougeController dialougeController;

    public List<GameObject> itemButtons;
    internal ProgressManager progressManager;

    internal int currentPage = 0;
    internal int pageOffset = 4;

    private void Awake()
    {
        progressManager = GameObject.FindGameObjectWithTag("SaveSystem").GetComponent<ProgressManager>();
    }

    internal int getButtonIndex(int buttonNumber)
    {
        return pageOffset * currentPage + buttonNumber;
    }

    public void ShowFightDialouge()
    {
        dialougeController.ShowCurrentFightDialouge();
    }
}
