using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text MyscoreText;
    [HideInInspector]public int ScoreNum;
    public string PlayerName;


    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = PlayerName + " : " + ScoreNum;
    }


    private void OnTriggerEnter2D(Collider2D Point)
    {
        if (Point.tag == "MyPoint")
        {
            ScoreNum += 1;
            Destroy(Point.gameObject);
            MyscoreText.text = PlayerName + " : " + ScoreNum;

        }
    }
}


