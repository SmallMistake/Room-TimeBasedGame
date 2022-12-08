using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPanel : MonoBehaviour
{
    ProgressManager manager;
    public GameObject visual;
    private bool visible = false;
    private bool changable = true;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("SaveSystem").GetComponent<ProgressManager>();
        visual.SetActive(visible);
    }

    private void FixedUpdate()
    {
        if(Input.GetButton("Debug1") && Input.GetButton("Debug2") && Input.GetButton("Debug3") && changable)
        {
            visible = !visible;
            visual.SetActive(visible);
            changable = false;
            StartCoroutine(ChangeableDelay());
        }
    }


    public void saveData()
    {
        manager.SaveProgress();
    }
    public void loadData()
    {
        manager.LoadSavedProgress();
    }
    public void resetData()
    {
        manager.CreateSaveGame();
    }

    IEnumerator ChangeableDelay()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        changable = true;
    }
}
