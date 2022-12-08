using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarController : MonoBehaviour
{
    public List<Image> healthBars;
    //Because the image for the health bar is at an angle 1 is well above the top of the bar. set this to make the fill match the top of the bar
    private float maxHealthBarPercent = .87f;

    public void SetPlayerHealthVisual(float percent)
    {
        float adjustedPercent = maxHealthBarPercent * percent;
        foreach (Image image in healthBars)
        {
            image.fillAmount = adjustedPercent;
        }
    }
}
