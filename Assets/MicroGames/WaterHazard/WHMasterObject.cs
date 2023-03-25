using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WHMasterObject : MonoBehaviour
{
    public TextMeshProUGUI p1Text;
    public TextMeshProUGUI p2Text;


    public bool p1Turn = false;
    public bool p2Turn = false;
    
    void Start()
    {
        p1Turn = true; p2Turn = false;
        p1Text.SetText("Player 1 Turn");
    }

    // Update is called once per frame
    void Update()
    {
        P1Jug p1Jug = GetComponentInChildren<P1Jug>();
        if(p1Jug.turnOver == true)
        {
            p1Turn = false; p2Turn = true;
            p1Jug.turnOver = false;
            p1Text.SetText("");
            p2Text.SetText("Player 2 Turn");
        }

        P2Jug p2Jug = GetComponentInChildren<P2Jug>();
        if (p2Jug.turnOver == true)
        {
            p2Turn = false; p1Turn = true;
            p2Jug.turnOver = false;
            p2Text.SetText("");
            p1Text.SetText("Player 1 Turn");
        }
    }

}
