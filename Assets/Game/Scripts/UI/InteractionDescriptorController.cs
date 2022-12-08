using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionDescriptorController : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemEffectText;
    public TextMeshProUGUI itemDescriptionText;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void ChangeInteractionDescriptor(string itemName, string itemEffect, string itemDescription)
    {
        itemNameText.text = itemName;
        itemEffectText.text = itemEffect;
        itemDescriptionText.text = itemDescription;
    }

    
}
