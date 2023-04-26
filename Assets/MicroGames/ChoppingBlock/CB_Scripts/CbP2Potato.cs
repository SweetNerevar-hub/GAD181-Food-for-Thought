using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CbP2Potato : MonoBehaviour
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
        MasterObjectScript masterObjectScript = GetComponentInParent<MasterObjectScript>();
        if (masterObjectScript.p1Win == true)
        {
            animator.SetBool("Player2Lose", true);
        }
        if (masterObjectScript.p2Win == true)
        {
            animator.SetBool("Player2Win", true);
        }
    }
}
