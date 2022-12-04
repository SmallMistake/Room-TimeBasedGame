using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour, I_Interactable
{
    public void InteractedWith(PlayerInventory playerInventory)
    {
        playerInventory.addKey(1);
        FMODUnity.RuntimeManager.CreateInstance("event:/SFX/KeyJingle").start();
        Destroy(gameObject);
    }
}
