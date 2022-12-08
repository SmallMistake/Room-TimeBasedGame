using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActionsMenu : RPGMenuBase
{

    private void OnEnable()
    {
        currentPage = 0;
        if (progressManager.cachedProgress.playerData.heldItems != null)
        {
            buildActionsList(progressManager.cachedProgress.playerData.unlockedActions);
        }
    }

    private void buildActionsList(List<RPGActionData> actions)
    {
        //TODO Add Pages
        for (int i = 0; i <= 3; i++)
        {
            if (i < actions.Count)
            {
                RPGActionData actionData = actions[i];
                string itemText = actionData.actionName;
                itemButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = itemText;
                itemButtons[i].SetActive(true);
            }
            else
            {
                itemButtons[i].SetActive(false);
            }
        }
    }

    public void useAction(int buttonPressed)
    {
        int buttonIndex = getButtonIndex(buttonPressed);
        RPGActionData actionUsed = progressManager.cachedProgress.playerData.unlockedActions[buttonIndex];
        fightManager.useAction(actionUsed);
    }

    public void ShowActionDescription(int buttonPressed)
    {
        int buttonIndex = getButtonIndex(buttonPressed);
        RPGActionData actionSelected = progressManager.cachedProgress.playerData.unlockedActions[buttonIndex];
        dialougeController.ShowInteractionDescription(actionSelected.actionName, actionSelected.baseAmount.ToString(), actionSelected.actionDescription);
    }
}
