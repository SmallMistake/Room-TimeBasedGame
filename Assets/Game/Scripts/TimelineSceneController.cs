using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimelineSceneController : MonoBehaviour
{
    public float timeTillMoveToNextScene = 5;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TODO Animate to show day has ended");
        StartCoroutine(moveToNextDay());
    }

    IEnumerator moveToNextDay()
    {
        yield return new WaitForSeconds(timeTillMoveToNextScene);
        SceneManager.LoadScene("SampleScene");
    }
}
