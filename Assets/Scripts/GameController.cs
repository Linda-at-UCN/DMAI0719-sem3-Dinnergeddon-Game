using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //Other scripts

    //Timers.
    public float spawnWaitTimer;
    public float startWaitTimer;
    public float playerConnectTimer;
    public GameHealth gameHealthScript;
    public PlayerHUD playerHUDScript;


    //Flags and scores.
    public int score = 0;
    private bool gameOver;
    private bool disconnect;

    // Use this for initialization
    void Start ()
    {
        //Flag for game being over, might be unneeded.
        gameOver = false;

        // TODO: Implement zombies spawns etc.

	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private void FixedUpdate()
    {
        if(gameHealthScript.health == 0)
        {
            GameOver();
        }
        // TODO: Replace this with starting auto-updating score
        score++;
    }

    private void GameOver()
    {
        //Freezes the game entirely.
        Time.timeScale = 0;
        playerHUDScript.GameOverMenuToggle();
    }

}
