using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CBPlayer1StartingAnimation : MonoBehaviour
{

    public int currentFrame = 0;
    public bool p1FirstInputDetected = false;
    public bool p1Dummy = false;
    public int p1InputCount = 0;

    void Start()
    {

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            p1FirstInputDetected = true;
        }
        else if (p1FirstInputDetected == true && p1Dummy == false)
        {
            Animator animator = GetComponent<Animator>();
            animator.SetInteger("currentFrame", currentFrame);
            animator.SetFloat("Speed", 0.0f);
            currentFrame++;
            p1Dummy = true;

        }
        else if (Input.GetKeyDown(KeyCode.S) && p1FirstInputDetected)
        {
            Animator animator = GetComponent<Animator>();
            animator.SetInteger("currentFrame", currentFrame);
            animator.SetFloat("Speed", 1.0f);
            currentFrame++;
            p1InputCount++;
            p1FirstInputDetected = false;
            p1Dummy = false;
        }
    }



}
