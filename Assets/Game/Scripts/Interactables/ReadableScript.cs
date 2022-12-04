using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadableScript : MonoBehaviour, I_Interactable
{
    public GameObject pageVisual;
    ReadableVisualController visualController;
    bool interactable = true;

    //Use with Interactable Script to simulate a book being opened
    public void InteractedWith(PlayerInventory playerInventory)
    {
        if(visualController == null )
        {
            visualController = FindObjectOfType<ReadableVisualController>();
        }

        if (interactable)
        {
            interactable = false;
            visualController.showReadable(pageVisual);
            StartCoroutine(delayReadAgain());
        }
    }

    IEnumerator delayReadAgain()
    {
        yield return new WaitForSeconds(0.05f);
        interactable = true;
    }
}
