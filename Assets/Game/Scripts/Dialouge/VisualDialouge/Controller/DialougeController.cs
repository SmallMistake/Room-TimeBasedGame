using UnityEngine;
using TMPro;
using VisualDialougeTree;

public class DialougeController : MonoBehaviour
{
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI dialougeText;
    private Animator animator;

    DialougeReader reader;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Select"))
        {
            bool anotherNode = reader.moveToNextNode();
            reader.readCurrentNode();
        }
    }


    public void StartDialouge(DialougeContainer dialouge)
    {
        animator.SetTrigger("StartDialouge");
        reader = new DialougeReader(dialouge);
        reader.readCurrentNode();
    }

    public void PauseTime()
    {
        Time.timeScale = 0;
    }


}
