using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public List<RPGActionData> unlockedActions;
    public List<InventoryEntry> heldItems;

    public void useItem(RPGItemData usedItem, int amount = 1)
    {
        for(int i = 0; i <= heldItems.Count; i++)
        {
            if(heldItems[i].item == usedItem)
            {
                heldItems[i].amountHeld -= amount;
                if(heldItems[i].amountHeld == 0)
                {
                    heldItems.Remove(heldItems[i]);
                }
                break;
            }
        }
    }
}
