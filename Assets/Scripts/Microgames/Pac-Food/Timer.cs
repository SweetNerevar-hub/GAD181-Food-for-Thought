using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{ 
    private int gameTimer;
    
 
    void Start()
    {
        gameTimer = 10;
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
        EventManager.instance.UpdateUI(3);
        
    }
    
}
