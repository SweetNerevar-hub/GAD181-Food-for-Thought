using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MasterObjectScript : MonoBehaviour
{
    public int p1Score;
    public int p2Score;

    public float targetTime = 11f;
    private float countdown = 4;
    
    public bool gameOver = false;
    public bool p1Win = false;
    public bool p2Win = false;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timeLeft;
    public TextMeshProUGUI p1ScoreDisplay;
    public TextMeshProUGUI p2ScoreDisplay;
    public TextMeshProUGUI countdownText;

    public GameObject CBTutorialImage;
    public SpriteRenderer CBTutorialImageSprite;
    public bool tutorialBool;
    public bool countdownBool;

    public void Start()
    {
        p1Win = false;
        p2Win = false;
        p1ScoreDisplay.SetText("");
        p2ScoreDisplay.SetText("");
        countdownText.SetText("");
        tutorialBool = true;
        countdownBool = true;
        CBTutorialImageSprite = CBTutorialImage.GetComponent<SpriteRenderer>();
        StartCoroutine(TutorialCoroutine());
    }
    void Update()
    {
        if(countdownBool == false)
        {
            int newTargetTime = (int)targetTime;
            timerText.SetText("Time left:");
            timeLeft.SetText("" + newTargetTime);
            CbPlayer1 cbPlayer1 = GetComponentInChildren<CbPlayer1>();
            p1Score = cbPlayer1.p1InputCount;
            CbPlayer2 cbPlayer2 = GetComponentInChildren<CbPlayer2>();
            p2Score = cbPlayer2.p2InputCount;
            targetTime -= Time.deltaTime;
        }
     

        if (targetTime <= 0.0f)
        {
            targetTime= 0.0f;
            timerEnded();
        }

        //Fades Tutorial image into game display
        if (tutorialBool == false)
        {
            FadeIntoGame();
        }
    }

    void timerEnded()
    {
        gameOver = true;
        timeLeft.SetText("");
        p1ScoreDisplay.SetText("Slices: " + p1Score);
        p2ScoreDisplay.SetText("Slices: " + p2Score);
        if (p1Score > p2Score)
        {
            timerText.SetText("Player 1 Wins!");
            p1Win = true;
        }
        if(p1Score < p2Score)
        {
            timerText.SetText("Player 2 Wins!");
            p2Win = true;
        }
        if(p1Score == p2Score)
        {
            timerText.SetText("Draw!");
            p1Win = true; p2Win = true;
        }
        Invoke("BackToMenu", 3f);
        targetTime = 1f;
        countdownBool = true;
    }

    IEnumerator TutorialCoroutine()
    {
        //Display tutorial image while disabling player input
        CBTutorialImageSprite.enabled = true;
        Debug.Log("Started Tutorial at timestamp : " + Time.time);


        //yield on a new YieldInstruction that waits for 4 seconds.
        yield return new WaitForSeconds(4.5f);

        //After we have waited 4 sec, displays game by activating "if" statement in Update
        tutorialBool = false;
        Debug.Log("Finished Tutorial at timestamp : " + Time.time);
        //FadeIntoGame();

    }

    void FadeIntoGame()
    {
        CBTutorialImageSprite.color = new Color(0f, 0f, 0f, 1f);
        int intCountdown = (int)countdown;
        countdownText.SetText(""+ intCountdown);
        countdown -= Time.deltaTime;
        //new WaitForSeconds(3);
        if(countdown <=0)
        {
            CBTutorialImageSprite.color = new Color(0f, 0f, 0f, 0f);
            countdownText.SetText("");
            countdownBool = false;
        }
    }

    void BackToMenu()
    {
        EventManager.instance.UpdateUI(2);
    }

}
