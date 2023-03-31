using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{ 
    private int gameTimer;
 
    void Start()
    {
        StartCoroutine(GameTimer());
    }
  
        IEnumerator GameTimer()
    {
        while (gameTimer > 0)
        {
            gameTimer--;

            yield return new WaitForSeconds(1);
        }
    }

}
