using UnityEngine;
using TMPro;

public class Stylized2DButtonHelper : MonoBehaviour
{
    Color hoveredColor = new Color(250f/255f, 251f / 255f, 246f / 255f);
    Color unselectedColor = new Color(86f / 255f, 90f / 255f, 117f / 255f);
    TextMeshProUGUI buttonText;

    private void Start()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        buttonText.color = unselectedColor;
    }

    public void onHover()
    {
        buttonText.color = hoveredColor;
    }

    public void onStopHover()
    {
        buttonText.color = unselectedColor;
    }
}
