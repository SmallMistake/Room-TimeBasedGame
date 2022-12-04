using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineController : MonoBehaviour
{

    private float spacingInterval = 250f;
    public DayController dayController;
    public GameObject timeline;
    // Start is called before the first frame update
    void Start()
    {
        float startingAmount = dayController.currentIndex * spacingInterval;
        timeline.transform.localPosition -= new Vector3(startingAmount, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
