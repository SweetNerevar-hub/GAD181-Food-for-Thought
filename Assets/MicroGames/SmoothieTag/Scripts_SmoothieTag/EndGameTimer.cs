using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameTimer : MonoBehaviour
{
    public float countDownTime = 5f;
    public TextMeshProUGUI countDownDisplay;
    public GameObject playerOne;
    public GameObject playerTwo;

    private void Start()
    {
      StartCoroutine(CountDownToEnd());
    }
    private void Update()
    {

    }
    public IEnumerator CountDownToEnd()
    {

        while (countDownTime > 0)
        {
            yield return new WaitForSeconds(1f);
            countDownTime--;
            countDownDisplay.text = countDownTime.ToString();
        }


        PlayerOneWin();

        countDownDisplay.gameObject.SetActive(false);


          Debug.Log("timerdone");
            
          Invoke("GameOver", 3f);
        
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
        Debug.Log("game end");
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
