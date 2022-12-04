using UnityEngine;
using UnityEngine.UI;

public class CalanderDayUI : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite crossedOutSprite;
    public Image spriteRenderer;
    public DayController dayController;

    public int representedDay;

    // Start is called before the first frame update
    void Start()
    {
        if (dayController != null & representedDay >= dayController.currentIndex ) //If represented day is after player's current day
        {
            spriteRenderer.sprite = normalSprite;
        }
        else
        {
            spriteRenderer.sprite = crossedOutSprite;
        }
    }
}
