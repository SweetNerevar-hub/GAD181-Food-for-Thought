using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CbP1Pear : MonoBehaviour
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
        if (masterObjectScript.p2Win == true)
        {
            animator.SetBool("Player1Lose", true);
        }
        if (masterObjectScript.p1Win == true)
        {
            animator.SetBool("Player1Win", true);
        }
    }
}
