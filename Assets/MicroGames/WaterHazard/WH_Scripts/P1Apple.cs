using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Apple : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        WHMasterObject wHMasterObject = GetComponentInParent<WHMasterObject>();
        if (wHMasterObject.p1Turn == true)
        {
            animator.SetBool("Player1Turn", true);
        }
        else
        {
            animator.SetBool("Player1Turn", false);
        }
        if(wHMasterObject.p2Win == true)
        {
            animator.SetBool("Player1Lose", true);
        }
        if (wHMasterObject.p1Win == true)
        {
            animator.SetBool("Player1Win", true);
        }
    }


}
