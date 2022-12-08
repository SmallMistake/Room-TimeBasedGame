using UnityEngine;
using UnityEngine.UI;

public class CalanderDayUI : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite crossedOutSprite;
    public Image spriteRenderer;
    public TimelineController timelineController;

    public int representedDay;

    // Start is called before the first frame update
    void Start()
    {
        if (timelineController != null & representedDay >= timelineController.progressManager.cachedProgress.currentDay ) //If represented day is after player's current day
        {
            spriteRenderer.sprite = normalSprite;
        }
        else
        {
            spriteRenderer.sprite = crossedOutSprite;
        }
    }
}
