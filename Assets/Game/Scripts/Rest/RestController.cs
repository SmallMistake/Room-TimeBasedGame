using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void ShowRestPanel()
    {
        animator.SetBool("PanelVisible", true);
        Time.timeScale = 0;
    }

    public void HideRestPanel()
    {
        animator.SetBool("PanelVisible", false);
    }
    public void RestartTime()
    {
        Time.timeScale = 1;
    }

    public void Rest()
    {
        print("TODO Rest");
    }
}
