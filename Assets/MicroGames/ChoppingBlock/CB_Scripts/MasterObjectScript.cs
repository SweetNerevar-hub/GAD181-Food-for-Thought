using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MasterObjectScript : MonoBehaviour
{
    public int p1Score;
    public int p2Score;

    public float targetTime = 10f;
    
    public bool gameOver = false;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timeLeft;
    public TextMeshProUGUI p1ScoreDisplay;
    public TextMeshProUGUI p2ScoreDisplay;

    public void Start()
    {
        p1ScoreDisplay.SetText("");
        p2ScoreDisplay.SetText("");
    }
    void Update()
    {
        int newTargetTime = (int)targetTime;
        timerText.SetText("Time left:");
        timeLeft.SetText(""+ newTargetTime);
        CbPlayer1 cbPlayer1 = GetComponentInChildren<CbPlayer1>();
        p1Score = cbPlayer1.p1InputCount;
        CbPlayer2 cbPlayer2 = GetComponentInChildren<CbPlayer2>();
        p2Score = cbPlayer2.p2InputCount;
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            targetTime= 0.0f;
            timerEnded();
        }

    }

    void timerEnded()
    {
        gameOver = true;
        timeLeft.SetText("");
        p1ScoreDisplay.SetText("Player 1 Slices: " + p1Score);
        p2ScoreDisplay.SetText("Player 2 Slices: " + p2Score);
        if (p1Score > p2Score)
        {
            timerText.SetText("Player 1 Wins!");
        }
        if(p1Score < p2Score)
        {
            timerText.SetText("Player 2 Wins!");
        }
        if(p1Score == p2Score)
        {
            timerText.SetText("Draw!");
        }
        Invoke("BackToMenu", 3f);
    }

    void BackToMenu()
    {
        EventManager.instance.UpdateUI(3);
    }

}
