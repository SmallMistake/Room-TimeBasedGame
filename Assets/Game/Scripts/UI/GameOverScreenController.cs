using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenController : MonoBehaviour
{
    private Animator animator;
    public GameObject menuContents;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        FightManager.gameOver += ShowGameOverMenu;
    }


    private void OnDestroy()
    {
        FightManager.gameOver -= ShowGameOverMenu;
    }
    
    private void ShowGameOverMenu()
    {
        animator.SetTrigger("StartGameOver");
    }

    public void TryFightAgain()
    {
        SceneManager.LoadScene("RPGFightScene");
    }

    public void TryDayAgain()
    {
        print("TODO Try Day Again");
    }

    public void GiveUp()
    {
        print("TODO Give Up");
    }
}
