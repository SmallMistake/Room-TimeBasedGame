using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int standardKeys = 0;

    public bool Contains(string objectToCheckFor)
    {
        //make this work
        return true;
    }

    public bool TryToUseKey(int numberOfKeysToUse = 1)
    {
        if(standardKeys - numberOfKeysToUse >= 0)
        {
            standardKeys -= numberOfKeysToUse;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void addKey(int keysToAdd)
    {
        standardKeys += keysToAdd;
    }
}
