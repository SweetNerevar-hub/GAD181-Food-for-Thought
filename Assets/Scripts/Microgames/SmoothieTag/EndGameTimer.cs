using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(3);

        countDownDisplay.gameObject.SetActive(false);
    }

}
