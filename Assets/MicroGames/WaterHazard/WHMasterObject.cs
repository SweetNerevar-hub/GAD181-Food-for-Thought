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
    
    void Start()
    {
        //Player 1 starts
        p1Turn = true; p2Turn = false;
        p1Text.SetText("Player 1 Turn");
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

        //Once Player1 is finished their turn, the parameters that allow they to play are
        //disabled, and the parameters for Player2 are enabled
        if (p1Jug.turnOver == true && gameOver == false)
        {
            p1Turn = false; p2Turn = true;
            p1Jug.turnOver = false;
            p1Text.SetText("");
            p2Text.SetText("Player 2 Turn");
        }

        //Once Player2 is finished their turn, the parameters that allow they to play are
        //disabled, and the parameters for Player1 are enabled
        if (p2Jug.turnOver == true && gameOver == false)
        {
            p2Turn = false; p1Turn = true;
            p2Jug.turnOver = false;
            p2Text.SetText("");
            p1Text.SetText("Player 1 Turn");
        }
        
    }

    void BackToMenu()
    {
        EventManager.instance.UpdateUI(3);
    }

}
