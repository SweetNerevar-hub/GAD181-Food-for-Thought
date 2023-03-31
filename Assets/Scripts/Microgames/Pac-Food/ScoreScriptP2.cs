using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScriptP2 : MonoBehaviour
{
    public Text MyscoreText;
    private int ScoreNum;


    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Player 2 : " + ScoreNum;
    }


    private void OnTriggerEnter2D(Collider2D Point)
    {
        if (Point.tag == "MyPoint")
        {
            ScoreNum += 1;
            Destroy(Point.gameObject);

        }
    }
}


