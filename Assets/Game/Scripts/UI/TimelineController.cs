using SaveSystem;
using UnityEngine;

public class TimelineController : MonoBehaviour
{

    private float spacingInterval = 250f;
    public GameObject timeline;
    internal ProgressManager progressManager;

    // Start is called before the first frame update
    void Awake()
    {
        progressManager = GameObject.FindGameObjectWithTag("SaveSystem").GetComponent<ProgressManager>();
        float startingAmount = progressManager.cachedProgress.currentDay * spacingInterval;
        timeline.transform.localPosition -= new Vector3(startingAmount, 0, 0);
    }
}
