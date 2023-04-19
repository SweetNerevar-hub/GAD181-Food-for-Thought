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
    
    public bool gameOver = false;
    public bool p1Win = false;
    public bool p2Win = false;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timeLeft;
    public TextMeshProUGUI p1ScoreDisplay;
    public TextMeshProUGUI p2ScoreDisplay;

    public GameObject CBTutorialImage;
    public SpriteRenderer CBTutorialImageSprite;
    private float tutorialTransparency = 1;
    public bool tutorialBool;

    public void Start()
    {
        p1Win = false;
        p2Win = false;
        p1ScoreDisplay.SetText("");
        p2ScoreDisplay.SetText("");
        tutorialBool = true;
        tutorialTransparency = 1;
        CBTutorialImageSprite = CBTutorialImage.GetComponent<SpriteRenderer>();
        StartCoroutine(TutorialCoroutine());
    }
    void Update()
    {
        if(tutorialBool == false)
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
    }

    IEnumerator TutorialCoroutine()
    {
        //Display tutorial image while disabling player input
        CBTutorialImageSprite.enabled = true;
        Debug.Log("Started Tutorial at timestamp : " + Time.time);


        //yield on a new YieldInstruction that waits for 4 seconds.
        yield return new WaitForSeconds(4);

        //After we have waited 4 sec, displays game by activating "if" statement in Update
        tutorialBool = false;
        Debug.Log("Finished Tutorial at timestamp : " + Time.time);

    }

    void FadeIntoGame()
    {
        CBTutorialImageSprite.color = new Color(1f, 1f, 1f, tutorialTransparency);
        if (tutorialTransparency > 0)
        {
            tutorialTransparency -= Time.deltaTime;
        }
        else
        {
            CBTutorialImageSprite.enabled = false;
        }
    }

    void BackToMenu()
    {
        EventManager.instance.UpdateUI(3);
    }

}
