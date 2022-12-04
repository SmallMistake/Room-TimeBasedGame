using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicationIndicator : MonoBehaviour
{
    private bool visible;
    public GameObject visual;
    public Animator animator;

    private void Start()
    {
        visible = false;
        visual.SetActive(visible);
    }

    public void SetVisible(bool visible)
    {
        this.visible = visible;
        visual.SetActive(visible);

    }
}
