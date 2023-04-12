using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
   
    public Animator _anim;
    public bool animation_bool;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

   /* public void Jump(bool jumping)
    {
        _anim.SetBool("Jumping", jumping);
    }
    */

 

    public void Update()
    {
        if(animation_bool == true)
        {
            _anim.Play("Jump");
        }
        if(Input.GetButtonDown("Space"))
        {
            animation_bool = true;
        }
    }



}
