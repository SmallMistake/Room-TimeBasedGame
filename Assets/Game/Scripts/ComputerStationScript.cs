using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerStationScript : MonoBehaviour, I_Interactable
{
    ProgressManager progressManager;
    public GameObject progressBar;
    private bool interactable;
    InteractableScript interactableScript;

    void Start()
    {
        interactableScript = GetComponent<InteractableScript>();
        progressBar.SetActive(false);
        progressManager = GameObject.FindGameObjectWithTag("SaveSystem").GetComponent<ProgressManager>();
    }

    public void InteractedWith(PlayerInventory playerInventory)
    {
        interactable = false;
        interactableScript.setInteractable(interactable);
        workOnGame();
    }

    void workOnGame()
    {
        progressManager.increaseAttribute(1, GameProgressAttributes.developmentProgress);
        progressBar.SetActive(true);
        StartCoroutine(finishWorkingOnGame());
    }

    IEnumerator finishWorkingOnGame()
    {
        yield return new WaitForSeconds(1);
        interactable = true;
        interactableScript.setInteractable(interactable);
        progressBar.SetActive(false);
    }
}
