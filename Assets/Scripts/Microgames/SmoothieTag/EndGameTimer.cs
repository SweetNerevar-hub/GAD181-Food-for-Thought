using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGameTimer : MonoBehaviour
{
    public int countDownTime;
    public TextMeshProUGUI countDownDisplay;


    private void Start()
    {
        StartCoroutine(CountDownToEnd());
    }
    IEnumerator CountDownToEnd()
    {
        while (countDownTime > 0)
        {
            countDownDisplay.text = countDownTime.ToString();
            yield return new WaitForSeconds(1f);

            countDownTime--;
        }

        


        Debug.Log("Game Over");

        yield return new WaitForSeconds(1f);

        countDownDisplay.gameObject.SetActive(false);
    }

}
