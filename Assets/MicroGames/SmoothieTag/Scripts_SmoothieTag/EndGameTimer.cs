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
    public GameObject playerOne;
    public GameObject playerTwo;

    private void Start()
    {
        StartCoroutine(CountDownToEnd());
    }
    public IEnumerator CountDownToEnd()
    {
        while (countDownTime > 0)
        {
            countDownDisplay.text = countDownTime.ToString();
            yield return new WaitForSeconds(4f);

            countDownTime--;
        }

        PlayerOneWin();

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(3);

        countDownDisplay.gameObject.SetActive(false);
    }

    public bool PlayerOneWin()
    {
        if (playerOne.GetComponent<ColourChange>().isTagged)
        {
            countDownDisplay.text = "P2!";
            return false;
        }
        else
        {
            countDownDisplay.text = "P1!";
            return true;
        }

    }

}
