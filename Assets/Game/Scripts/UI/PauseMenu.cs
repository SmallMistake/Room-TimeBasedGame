using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    private bool paused = false;

    public GameObject continueButton, quitButton;
    public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            pause(!paused);
        }
    }

    public void pause(bool newPauseStatus)
    {
        paused = newPauseStatus;
        if (paused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(continueButton);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }
}
