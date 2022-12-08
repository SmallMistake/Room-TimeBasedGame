using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemsMenu : RPGMenuBase
{
    private void OnEnable()
    {
        currentPage = 0;
        if (progressManager.cachedProgress.playerData.heldItems != null)
        {
            buildItemsList(progressManager.cachedProgress.playerData.heldItems);
        }
    }

    private void buildItemsList(List<InventoryEntry> heldItems)
    {
        //TODO Add Pages
        for(int i = 0; i <= 3; i++)
        {
            if (i < heldItems.Count)
            {
                InventoryEntry inventoryEntry = heldItems[i];
                string itemText = inventoryEntry.amountHeld + "x " + inventoryEntry.item.name;
                itemButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = itemText;
                itemButtons[i].SetActive(true);
            }
            else
            {
                itemButtons[i].SetActive(false);
            }
        }
    }

    public void useItem(int buttonPressed)
    {
        int buttonIndex = getButtonIndex(buttonPressed);
        RPGItemData itemBeingUsed = progressManager.cachedProgress.playerData.heldItems[buttonIndex].item;
        progressManager.cachedProgress.playerData.useItem(itemBeingUsed);
        fightManager.useItem(itemBeingUsed);
        buildItemsList(progressManager.cachedProgress.playerData.heldItems);
    }

    public void ShowItemDescription(int buttonPressed)
    {
        int buttonIndex = getButtonIndex(buttonPressed);
        RPGItemData itemSelected = progressManager.cachedProgress.playerData.heldItems[buttonIndex].item;
        dialougeController.ShowInteractionDescription(itemSelected.name, itemSelected.effectAmount.ToString(), itemSelected.description);
    }
}
