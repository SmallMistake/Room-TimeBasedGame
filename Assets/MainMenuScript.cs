using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainPage;
    public GameObject optionsPage;

    private GameObject currentPage;
    // Start is called before the first frame update
    void Start()
    {
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

    public void closeGame()
    {
        Application.Quit();
    }
}
