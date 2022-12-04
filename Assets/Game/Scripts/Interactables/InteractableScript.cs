using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionMethod
{
    A,
    B,
    InRange
}

public class InteractableScript : MonoBehaviour
{
    private bool inRange;
    I_Interactable interactionObject;
    public IndicationIndicator indicator;
    public InteractionMethod interactionMethod = InteractionMethod.A;

    PlayerInventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<PlayerInventory>();
        interactionObject = GetComponent<I_Interactable>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
            if(indicator != null)
            {
                indicator.SetVisible(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
            if(indicator != null)
            {
                indicator.SetVisible(false);
            }
        }
    }

    private void Update()
    {
        if (inRange)
        {
            switch (interactionMethod)
            {
                case InteractionMethod.A:
                    if (Input.GetButtonDown("A"))
                    {
                        interactionObject.InteractedWith(inventory);
                    }
                    break;
                case InteractionMethod.B:
                    if (Input.GetButtonDown("B"))
                    {
                        interactionObject.InteractedWith(inventory);
                    }
                    break;
                case InteractionMethod.InRange:
                    interactionObject.InteractedWith(inventory);
                    break;
            }
        }
    }

    public void OnDestroy()
    {
        if(indicator != null)
        {
            indicator.SetVisible(false);
        }
    }
}
