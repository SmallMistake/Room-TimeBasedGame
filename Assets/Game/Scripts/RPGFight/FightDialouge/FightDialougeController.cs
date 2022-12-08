using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightDialougeController : MonoBehaviour
{
    public TextMeshProUGUI fightText;
    public InteractionDescriptorController interactionDescriptorController;

    public FightDialougeTemplate fightDialouge;
    private int currentDialougeIndex = 0;

    void Start()
    {
        ShowCurrentFightDialouge();

        PlayerPhase.startPlayerPhase += MoveToNextFightDialouge;
    }

    public void MoveToNextFightDialouge()
    {

        /*FightDialougeInstance dialouge = new FightDialougeInstance()
        {
            dialouge = fightDialouge.statements[currentDialougeIndex]
        };
        */
        fightText.gameObject.SetActive(true);
        interactionDescriptorController.gameObject.SetActive(false);
        currentDialougeIndex++;

        if (currentDialougeIndex >= fightDialouge.statements.Count)
        {
            currentDialougeIndex = fightDialouge.statements.Count - 1;
        }
        fightText.text = fightDialouge.statements[currentDialougeIndex];
    }

    public void ShowCurrentFightDialouge()
    {
        fightText.gameObject.SetActive(true);
        interactionDescriptorController.gameObject.SetActive(false);
        fightText.text = fightDialouge.statements[currentDialougeIndex];
    }

    public void ShowInteractionDescription(string name, string effectAmount, string description)
    {
        fightText.gameObject.SetActive(false);
        interactionDescriptorController.gameObject.SetActive(true);
        interactionDescriptorController.ChangeInteractionDescriptor(name, effectAmount, description);
    }

}
