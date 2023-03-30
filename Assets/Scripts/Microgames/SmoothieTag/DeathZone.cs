using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{  
    private EndGameTimer timer;
    private void Start()
    {
        timer = GameObject.Find("CountDown_Text").GetComponent<EndGameTimer>();
    }
    
    //script kills players on fall in zone.
    void OnTriggerEnter2D(Collider2D other)
    {
       

        if(!timer.PlayerOneWin())
        {
            timer.countDownDisplay.text = "Player 2";
            Destroy(other.gameObject);
        }
        else
        {
            timer.countDownDisplay.text = "Player 1";
            Destroy(other.gameObject);
        }


        timer.countDownTime = 0;
        timer.StartCoroutine(timer.CountDownToEnd()); 
        SceneManager.LoadScene(3);
    }

   

}
