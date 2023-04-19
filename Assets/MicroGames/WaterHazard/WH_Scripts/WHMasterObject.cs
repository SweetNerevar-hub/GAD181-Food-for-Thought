using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WHMasterObject : MonoBehaviour
{
    public TextMeshProUGUI p1Text;
    public TextMeshProUGUI p2Text;
    public TextMeshProUGUI winnerText;

    public bool p1Turn = false;
    public bool p2Turn = false;
    public bool gameOver = false;

    public GameObject WHTutorialImage;
    public SpriteRenderer WHTutorialImageSprite;
    private float tutorialTransparency = 1;
    private bool tutorialBool;

    public GameObject p1ControlSpriteObject;
    public SpriteRenderer p1ControlSprite;
    public GameObject p2ControlSpriteObject;
    public SpriteRenderer p2ControlSprite;

    void Start()
    {
        //Sanity Checks
        p1Turn = false;
        p2Turn = false;
        gameOver = false;
        tutorialBool = true;

        //Coroutine that displays tutorial for 4 sec with player input disabled, 
        //then displays game and enables player 1 input.
        WHTutorialImageSprite = WHTutorialImage.GetComponent<SpriteRenderer>();
        StartCoroutine(TutorialCoroutine());     
    }

    void Update()
    {
        P1Jug p1Jug = GetComponentInChildren<P1Jug>();
        P2Jug p2Jug = GetComponentInChildren<P2Jug>();
        CupScript cupScript = GetComponentInChildren<CupScript>();

        //If Player1 ends turn with cup over capacity, Player2 wins
        if (p1Jug.turnOver == true && cupScript.currentFrame >= 20)
        {
            p1Turn = false; p2Turn = false;
            gameOver = true;
            p1Text.SetText("");
            p2Text.SetText("");
            winnerText.SetText("Player 2 Wins!");
            Invoke("BackToMenu", 3f);
        }

        //If Player2 ends turn with cup over capacity, Player1 wins
        if (p2Jug.turnOver == true && cupScript.currentFrame >= 20)
        {
            p1Turn = false; p2Turn = false;
            gameOver = true;
            p1Text.SetText("");
            p2Text.SetText("");
            winnerText.SetText("Player 1 Wins!");
            Invoke("BackToMenu", 3f);
        }

        //Once Player1 is finished their turn, the parameters that allow them to play are
        //disabled, and the parameters for Player2 are enabled
        if (p1Jug.turnOver == true && gameOver == false)
        {
            p1Turn = false; p2Turn = true;
            p1Jug.turnOver = false;
            p1Text.SetText("");
            p2Text.SetText("Player 2 Turn");
            p1ControlSprite.enabled = false;
            p2ControlSprite.enabled = true;
        }

        //Once Player2 is finished their turn, the parameters that allow them to play are
        //disabled, and the parameters for Player1 are enabled
        if (p2Jug.turnOver == true && gameOver == false)
        {
            p2Turn = false; p1Turn = true;
            p2Jug.turnOver = false;
            p2Text.SetText("");
            p1Text.SetText("Player 1 Turn");
            p2ControlSprite.enabled = false;
            p1ControlSprite.enabled = true;
        }

        //Fades Tutorial image into game display
        if(tutorialBool == false)
        {
            FadeIntoGame();
        }       
    }

    //Coroutine that displays tutorial for 4 sec with player input disabled, 
    //then displays game and enables player 1 input.
    IEnumerator TutorialCoroutine()
    {
        //Display tutorial image while disabling player input
        WHTutorialImageSprite.enabled = true;
        Debug.Log("Started Tutorial at timestamp : " + Time.time);
        

        //yield on a new YieldInstruction that waits for 4 seconds.
        yield return new WaitForSeconds(4);

        //After we have waited 4 sec, displays game by activating "if" statement in Update
        tutorialBool = false;
        Debug.Log("Finished Tutorial at timestamp : " + Time.time);

        //Enables Player 1's input
        p1Turn = true; p2Turn = false;
        p1Text.SetText("Player 1 Turn");
        p1ControlSprite = p1ControlSpriteObject.GetComponent<SpriteRenderer>();
        p2ControlSprite = p2ControlSpriteObject.GetComponent<SpriteRenderer>();
    }

    //lowers opacity of tutorial image to reveal game display
    void FadeIntoGame()
    {
        WHTutorialImageSprite.color = new Color(1f, 1f, 1f, tutorialTransparency);
        if (tutorialTransparency > 0)
        {
            tutorialTransparency -= Time.deltaTime;
        }
        else
        {
            WHTutorialImageSprite.enabled = false;
        }
    }

    //goes back to game selection 3 sec after game end
    void BackToMenu()
    {
        EventManager.instance.UpdateUI(3);
    }

}
