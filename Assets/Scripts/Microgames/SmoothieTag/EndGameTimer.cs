using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGameTimer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public TextMeshProUGUI TimerText;

    void Start()
    {
        TimerOn = true;
    }

   
    void Update()
    {
        if(TimerOn)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
            }
            else
            {
                Debug.Log("time is done");
                TimeLeft = 0;
                TimerOn = false;
            }
            while(TimeLeft > 0)
            {
                TimerText.text = TimeLeft.ToString();
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);
        TimerText.text = string.Format("(0)", seconds);
    }
}
