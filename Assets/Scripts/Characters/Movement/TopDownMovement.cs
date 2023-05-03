using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TopDownMovement : MonoBehaviour {

    Rigidbody2D rb;
    Animator animator;

    //float h, v;

    public float speed;
    public bool playerOne;
    

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        /*
        InputManager.instance.MoveUp += MoveUp;
        InputManager.instance.MoveDown += MoveDown;
        InputManager.instance.MoveLeft += MoveLeft;
        InputManager.instance.MoveRight += MoveRight;
        */
    }

    private void Update() {
        PlayerInputCheck();
    }

    void PlayerInputCheck() {
        switch (playerOne) {
            case true:
                if (Input.GetKey(KeyCode.W))
                {
                    Movement(Vector2.up);
                    animator.SetInteger("Vertical", 1);
                }

                else if (Input.GetKey(KeyCode.S))
                {
                    Movement(Vector2.down);
                    animator.SetInteger("Vertical", -1);
                }

                else if (Input.GetKey(KeyCode.A))
                {
                    Movement(Vector2.left);
                    animator.SetInteger("Horizontal", -1);

                }

                else if (Input.GetKey(KeyCode.D))
                {
                    Movement(Vector2.right);
                    animator.SetInteger("Horizontal", 1);

                }

                if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
                {
                    animator.SetInteger("Vertical", 0);
                }
                if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    animator.SetInteger("Horizontal", 0);
                }

                break;

            case false:
                if (Input.GetKey(KeyCode.UpArrow)) {
                    Movement(Vector2.up);
                    animator.SetInteger("Vertical", 1);
                }

                else if (Input.GetKey(KeyCode.DownArrow)) {
                    Movement(Vector2.down);
                    animator.SetInteger("Vertical", -1);
                }

                else if (Input.GetKey(KeyCode.LeftArrow)) {
                    Movement(Vector2.left);
                    animator.SetInteger("Horizontal", -1);
                  
                }

                else if (Input.GetKey(KeyCode.RightArrow)) {
                    Movement(Vector2.right);
                    animator.SetInteger("Horizontal", 1);
                   
                }

                 if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
                {
                    animator.SetInteger("Vertical", 0);
                }
                if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
                {
                    animator.SetInteger("Horizontal", 0);
                }

                    break;
        }
    }

    void Movement(Vector2 dir) {
        rb.velocity = dir * speed;
    }

    private void OnDisable() {
        /*
        InputManager.instance.MoveUp -= MoveUp;
        InputManager.instance.MoveDown -= MoveDown;
        InputManager.instance.MoveLeft -= MoveLeft;
        InputManager.instance.MoveRight -= MoveRight;
        */
    }

    
}
