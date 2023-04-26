using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartCount : MonoBehaviour
{
    public int startCountTime;
    public TextMeshProUGUI startCountDisplay;

    public GameObject startGame;
    public static bool isPlaying;

    public GameObject player;
    public GameObject player2;

    private void Start()
    {
        PauseGame();
        StartCoroutine(CountDownToStart());
    }

    public IEnumerator CountDownToStart()
    {
        while (startCountTime > 0)
        {
            startCountDisplay.text = startCountTime.ToString();
            yield return new WaitForSeconds(1f);

            startCountTime--;
        }

        startCountDisplay.text = "Fight !";
        yield return new WaitForSeconds(2f);
        ResumeGame();
        
        

        
      
    }
 
    public void PauseGame()
    {
        startGame.SetActive(true);
        isPlaying = false;
        player.GetComponent<SideOnMovement>().enabled = false;
        player2.GetComponent<SideOnMovement>().enabled = false;
        Debug.Log("is paused");
    }

    public void ResumeGame()
    {
        startGame.SetActive(false);
        Time.timeScale = 1f;
        isPlaying = true;
        player.GetComponent<SideOnMovement>().enabled = true;
        player2.GetComponent<SideOnMovement>().enabled = true;
        Debug.Log("is Playing");
    }
}
