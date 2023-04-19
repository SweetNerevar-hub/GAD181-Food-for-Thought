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
        startGame.SetActive(false);

        ResumeGame();
      
    }
 
    public void PauseGame()
    {
        startGame.SetActive(true);
        isPlaying = false;
        Debug.Log("is paused");
    }

    public void ResumeGame()
    {
        startGame.SetActive(false);
        Time.timeScale = 1f;
        isPlaying = true;
        Debug.Log("is Playing");
    }
}
