using System.Collections;
using UnityEngine;
using VisualDialougeTree;
using FMODUnity;

public class chestScript : MonoBehaviour, I_Interactable
{
    private bool playerInRange = false;
    public DialougeContainer openedChestDialouge;
    public Sprite openedSprite;
    public Sprite unlockedSprite;
    public Sprite lockedSprite;
    public Sprite failedOpenSprite;
    private SpriteRenderer spriteRenderer;

    //State parameters
    public bool locked;
    private bool opened;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (locked)
        {
            spriteRenderer.sprite = lockedSprite;
        }
        else
        {
            spriteRenderer.sprite = unlockedSprite;
        }
    }

    public void InteractedWith(PlayerInventory inventory)
    {
        if (!locked) // Check if Locked
        {
            Open();
        } 
        else {
            if (inventory.TryToUseKey()) //Try to unlock
            {
                Open();
            }
            else //Fail to unlock
            {
                StartCoroutine(FailToOpenChest());
            }
        }
    }

    private void Open()
    {
        spriteRenderer.sprite = openedSprite;
        RuntimeManager.CreateInstance("event:/SFX/OpenChest").start();
        Destroy(GetComponent<InteractableScript>());
    }

    IEnumerator FailToOpenChest()
    {
        RuntimeManager.CreateInstance("event:/LockFail").start();
        spriteRenderer.sprite = failedOpenSprite;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.sprite = lockedSprite;
    }
}
