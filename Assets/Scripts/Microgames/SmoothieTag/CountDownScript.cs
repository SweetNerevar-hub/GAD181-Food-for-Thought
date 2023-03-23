using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownScript : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay; //change to TMP. Text mesh pro

    IEnumerator CountDownToEnd()
    {
        while(countdownTim > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

       // GameController.instance.EndGame(); have to call endgame screen script

        yield return new waitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);
    }

}
