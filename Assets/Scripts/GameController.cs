using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text livesText;
    public int lives;
    public Text scoreText;
    public int score;
    
    //meri vreme; za potencijalne levele
    public Text timeText;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;
   
    public Text restartText;
    public Text gameOverText;

    //ako flag bude true u nekom trenutku, izaci ce iz igre(mozda u pocetni meni)
    //private bool gameOver;
    private bool restart;



    void Start()
    {
        lives = 3;
        score = 0;
       
       // gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        
        UpdateScore();
        UpdateLives();
    }

    void Update()
    {
        UpdateTimerUI();
        CheckForRestart();

        if (lives <= 0)
            GameOver();
    }

    //updateuj score i pozovi metodu koja ispisuje na UI
    public void UpdateScore(int scoreIncrement)
    {
        score += scoreIncrement;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    //updateuje zivote, i proverava da li je kraj igre;poziva metodu koja ispisuje na UI
    public void UpdateLives(int livesDecrement)
    {
        lives -= livesDecrement;
        UpdateLives();        
    }

    void UpdateLives()
    {
        livesText.text = "Lives: " + lives;
    }

    //ako je kraj igre flegovi za gameOver i restart su true;ponovo loaduj scenu
    public void CheckForRestart()
    {
        if (restart)
        {
            restartText.text = "Press 'R' for Restart"; 
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    //tajmer metoda
    public void UpdateTimerUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        timeText.text ="Timer: " + hourCount + "h:" + minuteCount + "m:" + (int)secondsCount + "s";
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }

    public void GameOver()
    {
        gameOverText.text = "GAME OVER!!";
        //gameOver = true;
        restart = true;
    }

}
