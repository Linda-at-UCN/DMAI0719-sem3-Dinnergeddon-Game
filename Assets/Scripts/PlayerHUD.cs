using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour {


    //Required functionality objects.
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI scoreText;
    public GameHealth gameHealthScript;
    public GameController gameControllerScript;
    public CanvasGroup gameOverGroup;
    public CanvasGroup gameQuitGroup;



    // Use this for initialization
    void Start () {

        playerHealthText.text = gameHealthScript.health.ToString();
        // Player's personal score.
        scoreText.text = gameControllerScript.score.ToString();

        //Hide the "game over" group
        gameOverGroup.alpha = 0f;
        //Make the "game over" group uninteractable.
        gameOverGroup.interactable = false;

        //Hide the "game quit" group
        gameQuitGroup.alpha = 0f;
        //Make the "game quit" group uninteractable.
        gameQuitGroup.interactable = false;

    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGameMenuToggle();
        }
    }

    private void FixedUpdate()
    {
        //May need to move these outside of Update methods, unsure. - Dimitar
        playerHealthText.text = gameHealthScript.health.ToString();
        // TODO: Replace this with starting auto-updating score
        scoreText.text = gameControllerScript.score.ToString();
    }

    public void GameOverMenuToggle()
    {
        //Displays the "game over" group.
        gameOverGroup.alpha = 1f;
        //Makes the game over group interactably.
        gameOverGroup.interactable = true;
        //
        //Possibly add session score board for all players.
        //
    }

    public void QuitGameMenuToggle()
    {
        if (gameQuitGroup.alpha == 0f && gameQuitGroup.interactable == false)
        {
            //Displays the "game quit" group
            gameQuitGroup.alpha = 1f;
            //Makes the "game quit" group interactable.
            gameQuitGroup.interactable = true;
        }
        else if (gameQuitGroup.alpha == 1f && gameQuitGroup.interactable == true)
        {
            ////Hide the "game over" group
            //gameOverGroup.alpha = 0f;
            ////Make the "game over" group uninteractable.
            //gameOverGroup.interactable = false;
            QuitNo();
        }
    }

    public void QuitNo()
    {
        //Hide the "game quit" group
        gameQuitGroup.alpha = 0f;
        //Make the "game quit" group uninteractable.
        gameQuitGroup.interactable = false;
    }

    public void QuitYes()
    {
        Application.Quit();
    }
}
