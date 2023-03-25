using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WHMasterObject : MonoBehaviour
{


    
    public bool p1Turn = false;
    public bool p2Turn = false;
    
    void Start()
    {
        p1Turn = true; p2Turn = false;
    }

    // Update is called once per frame
    void Update()
    {
        P1Jug p1Jug = GetComponentInChildren<P1Jug>();
        if(p1Jug.turnOver == true)
        {
            p1Turn = false; p2Turn = true;
            p1Jug.turnOver = false;
        }
    }

}
