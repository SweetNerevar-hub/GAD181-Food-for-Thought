using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterObjectScript : MonoBehaviour
{
    public int p1Score;
    public int p2Score;

    public float targetTime = 10.0f;
    public bool gameOver = false;

    public void Start()
    {
        
        
    }
    void Update()
    {
        CbPlayer1 cbPlayer1 = GetComponentInChildren<CbPlayer1>();
        p1Score = cbPlayer1.p1InputCount;
        CbPlayer2 cbPlayer2 = GetComponentInChildren<CbPlayer2>();
        p2Score = cbPlayer2.p2InputCount;
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
        Debug.Log("Times Up!");
        gameOver = true;
    }

}
