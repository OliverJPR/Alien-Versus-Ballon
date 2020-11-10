using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isPlaying = true;
    public Boolean pausa = true;
    public Button btnPause;
    public TextMeshProUGUI lblPausa,lblScore,lblExploted,lblTimer;
    public GameObject btnReset, btnContinue;
    private int Score = 0;
    public GameObject ship;
    private float gameTime = 0f;
    public float counter = 0;

    void Awake()
    {
        lblScore.SetText(Score.ToString());
        Instance = this;
        lblPausa.enabled = false;
        lblExploted.enabled = false;
        btnContinue.SetActive(false);
        btnReset.SetActive(false);

    }

    public void Update()
    {
        if(ship == null)
        {
            Time.timeScale = 0;
            lblExploted.enabled = true;
            btnReset.SetActive(true);
        }
        gameTime += Time.deltaTime;
        int seconds = (int)(gameTime % 60);
        int minutes = (int)(gameTime / 60) % 60;
      
        string timeStrin = string.Format("{0:0}:{1:00}", minutes, seconds);
        lblTimer.SetText(timeStrin);

        counter += Time.deltaTime;
        if (counter >= 10)
        {
            //Increment Speed by 4
            minusPoints();

            //RESET Counter
            counter = 0;
        }



    }

    public void minusPoints()
    {
        Score -= 5;
        lblScore.text = Score.ToString();
        if(Score < 0)
        {
            Time.timeScale = 0;
            lblPausa.SetText("Game Over!!");
            lblPausa.enabled = true;
            btnReset.SetActive(true);
        }
    }

    public void pausar()
    {
        print("pause");
        if (pausa)
        {
            Time.timeScale = 0;
            lblPausa.enabled = true;
            btnReset.SetActive(true);
            btnContinue.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            lblPausa.enabled = false;
            btnReset.SetActive(false);
            btnContinue.SetActive(false);
        }

    }

    public void continuePlaying(){

        Time.timeScale = 1;
        lblPausa.enabled = false;
        btnReset.SetActive(false);
        btnContinue.SetActive(false);
    }

    public void restartGame()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        Score = 0;
        print("restart");
    }

    public void updateScore(int num)
    {
        Score += num;
        
        if (Score >= 500)
        {
            Time.timeScale = 0;
            lblPausa.SetText("You Win!!");
            lblPausa.enabled = true;
            btnReset.SetActive(true);
           
        }
        lblScore.SetText(Score.ToString());
    }
}
