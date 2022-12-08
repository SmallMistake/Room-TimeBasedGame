using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ItemType { heal}

[CreateAssetMenu(fileName = "RPGItem", menuName = "RPG/RPGItem", order = 1)]
public class RPGItem: ScriptableObject
{
    public RPGItemData itemData;
}

[System.Serializable]
public class RPGItemData {
    public string name;
    public ItemType type;
    public int effectAmount;

    public string description;

}

