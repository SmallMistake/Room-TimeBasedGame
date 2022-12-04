using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayEndCanvasController : MonoBehaviour
{
    public GameObject visual;
    private bool dayEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        Timer.timerFinished += ShowVisual;
        visual.SetActive(false);
    }

    public void ShowVisual()
    {
        visual.SetActive(true);
        dayEnded = true;

    }

    private void OnDestroy()
    {
        Timer.timerFinished -= ShowVisual;
    }

    private void Update()
    {
        if (dayEnded)
        {
            if (Input.GetButtonDown("A"))
            {
                SceneManager.LoadScene("DayStartScene");
            }
        }
    }
}
