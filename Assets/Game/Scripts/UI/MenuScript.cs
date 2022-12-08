using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour
{
    public GameObject firstButton;
    public GameObject backupButton;
    private GameObject currentButton;
    

    //This is done due to the execution order of the MainMenu ContinueButton
    private bool firstInit = true;

    private void Start()
    {
        setSelectedButton();
    }

    private void OnEnable()
    {
        if (!firstInit)
        {
            setSelectedButton();
        }
        else
        {
            firstInit = false;
        }
    }

    private void setSelectedButton()
    {
        if (currentButton == null)
        {
            if (firstButton.activeSelf == true)
            {
                currentButton = firstButton;
            }
            else
            {
                currentButton = backupButton;
            }
        }
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(currentButton);
    }

    private void OnDisable()
    {
        if (EventSystem.current != null)
        {
            currentButton = EventSystem.current.currentSelectedGameObject;
        }
    }
}
