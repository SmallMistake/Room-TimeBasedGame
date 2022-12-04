using UnityEngine;
using VisualDialougeTree;

public class InteractionController : MonoBehaviour
{
    DialougeController dialougeController;

    private void Start()
    {
       dialougeController = GameObject.FindObjectOfType<DialougeController>();
    }

    public void DisplayDialouge(DialougeContainer dialouge)
    {
        dialougeController.StartDialouge(dialouge);
    }
}
