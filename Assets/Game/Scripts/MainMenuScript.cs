using SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainPage;
    public GameObject optionsPage;
    public GameObject continueButton;

    private GameObject currentPage;
    ProgressManager progressManager;


    // Start is called before the first frame update
    void Awake()
    {
        progressManager = GameObject.FindGameObjectWithTag("SaveSystem").GetComponent<ProgressManager>();
        setContinueButton();
        mainPage.SetActive(true);
        optionsPage.SetActive(false);
        currentPage = mainPage;
    }

    public void changePage(GameObject pageToChangeTo)
    {
        currentPage.SetActive(false);
        pageToChangeTo.SetActive(true);
        currentPage = pageToChangeTo;

    }

    private void setContinueButton()
    {
        if(progressManager.cachedProgress.currentDay <= 0)
        {
            continueButton.SetActive(false);
        }
        else
        {
            continueButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Continue (Day {progressManager.cachedProgress.currentDay})";
        }
    }

    public void closeGame()
    {
        Application.Quit();
    }

    public void startNewGame()
    {
        ProgressManager progress = GameObject.FindGameObjectWithTag("SaveSystem").GetComponent<ProgressManager>();
        progress.CreateSaveGame();
        SceneManager.LoadScene("OpeningCutscene");
    }
}
