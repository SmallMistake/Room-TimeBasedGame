using UnityEngine;

public class DoorScript : MonoBehaviour, I_Interactable
{
    public GameObject openDoor;
    public GameObject closedDoor;
    public bool opened = false;

    private void Start()
    {
        SetVisual();
    }

    public void InteractedWith(PlayerInventory playerInventory)
    {
        opened = !opened;
        SetVisual();
    }

    private void SetVisual()
    {
        if (opened)
        {
            openDoor.SetActive(true);
            closedDoor.SetActive(false);
        }
        else
        {
            openDoor.SetActive(false);
            closedDoor.SetActive(true);
        }
    }
}
