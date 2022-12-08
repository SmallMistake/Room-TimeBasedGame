using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningCutscene : MonoBehaviour
{
    public void moveToFirstScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
