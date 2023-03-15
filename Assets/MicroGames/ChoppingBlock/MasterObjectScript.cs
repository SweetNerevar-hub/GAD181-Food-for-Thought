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

    public void Start()
    {
        
        
    }
    void Update()
    {
        timerText.SetText("Time left: " + targetTime);
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
        if(p1Score > p2Score)
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
    }

}
