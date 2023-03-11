using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float targetTime = 15.0f;
    public bool gameOver = false;
    
    
    

    void update()
    {

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

