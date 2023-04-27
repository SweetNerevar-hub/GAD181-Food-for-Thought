using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{ 
    private int gameTimer;
    public ScoreScript P1Score, P2Score;
    
 
    void Start()
    {
        gameTimer = 15;
        StartCoroutine(GameTimer());
        
    }
  
        IEnumerator GameTimer()
    {
        while (gameTimer > 0)
        {
            gameTimer--;
            GetComponent<Text>().text = gameTimer.ToString();
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(1);
        EventManager.instance.UpdateUI(2);
       if (Mathf.Max(P1Score.ScoreNum, P2Score.ScoreNum) == P1Score.ScoreNum)
        {
            P1Score.MyscoreText.text = P1Score.PlayerName + " Wins!!";
            P2Score.MyscoreText.text = P2Score.PlayerName + " Loses!!";
            
        }
       else
        {
            P1Score.MyscoreText.text = P1Score.PlayerName + " Loses!!";
            P2Score.MyscoreText.text = P2Score.PlayerName + " Wins!!";
        }
    }
    
}
