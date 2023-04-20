using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideOnMovement : MonoBehaviour {

    Rigidbody2D rb;
    Animator animator;

    public bool playerOne;
    public float jumpForce, speed;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        /*
        InputManager.instance.Jump += Jump;
        InputManager.instance.MoveRight += Movement;
        InputManager.instance.MoveLeft += Movement;
        */
    }

    private void Update() {
        IsGroundedCheck();
        PlayerInputCheck();
    }

    void IsGroundedCheck() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.3f);

        if (!hit) {
            animator.SetBool("Jumping", true);
        }

        else if (hit.collider.tag == "Ground") {
            animator.SetBool("Jumping", false);
        }
    }

    void PlayerInputCheck() {
        switch (playerOne) {
            case true:
                if (Input.GetKeyDown(KeyCode.Space)) {
                   Jump();
                }

                if (Input.GetKey(KeyCode.A)) {
                    Movement(Vector2.left);

                    animator.SetInteger("Horizontal", -1);
                }

                else if (Input.GetKey(KeyCode.D)) {
                    Movement(Vector2.right);

                    animator.SetInteger("Horizontal", 1);
                }

                else if(!Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D)) {
                    Movement(Vector2.zero);

                    animator.SetInteger("Horizontal", 0);
                }

                break;

            case false:
                if (Input.GetKeyDown(KeyCode.RightShift)) {
                    Jump();
                }

                if (Input.GetKey(KeyCode.LeftArrow)) {
                    Movement(Vector2.left);

                    animator.SetInteger("Horizontal", -1);
                }

                else if (Input.GetKey(KeyCode.RightArrow)) {
                    Movement(Vector2.right);

                    animator.SetInteger("Horizontal", 1);
                }
                
                else if (!Input.GetKey(KeyCode.LeftApple) || !Input.GetKey(KeyCode.RightArrow)) {
                    Movement(Vector2.zero);

                    animator.SetInteger("Horizontal", 0);
                }

                break;
        }        
    }

    void Jump() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.3f);

        if (!hit) {
            return;
        }

        else if(hit.collider.tag == "Ground") {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
      
    }

    void Movement(Vector2 dir) {
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "FFF_CollectableFood") {
            EventManager.instance.FFF_CollectFood(playerOne, col.gameObject);
        }
    }

    private void OnDisable() {

        // Is called when the script is disabled
        // Stop conflicts between the switching from top-down to side-on movement

        /*
        InputManager.instance.Jump -= Jump;
        InputManager.instance.MoveRight -= Movement;
        InputManager.instance.MoveLeft -= Movement;
        */

    }
}
