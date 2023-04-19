using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Broc : MonoBehaviour
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
        if (wHMasterObject.p2Turn == true)
        {
            animator.SetBool("Player2Turn", true);
        }
        else
        {
            animator.SetBool("Player2Turn", false);
        }

        if (wHMasterObject.p1Win == true)
        {
            animator.SetBool("Player2Lose", true);
        }
        if (wHMasterObject.p2Win == true)
        {
            animator.SetBool("Player2Win", true);
        }
    }
}
