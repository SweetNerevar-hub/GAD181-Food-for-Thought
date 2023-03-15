using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideOnMovement : MonoBehaviour {

    Rigidbody2D rb;

    public bool playerOne;
    public float jumpForce, speed;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();

        /*
        InputManager.instance.Jump += Jump;
        InputManager.instance.MoveRight += Movement;
        InputManager.instance.MoveLeft += Movement;
        */
    }

    private void Update() {
        PlayerInputCheck();
    }

    void PlayerInputCheck() {
        switch (playerOne) {
            case true:
                if (Input.GetKeyDown(KeyCode.Space)) {
                    Jump();
                }

                if (Input.GetKey(KeyCode.A)) {
                    Movement(Vector2.left);
                }

                else if (Input.GetKey(KeyCode.D)) {
                    Movement(Vector2.right);
                }

                break;

            case false:
                if (Input.GetKeyDown(KeyCode.RightShift)) {
                    Jump();
                }

                if (Input.GetKey(KeyCode.LeftArrow)) {
                    Movement(Vector2.left);
                }

                else if (Input.GetKey(KeyCode.RightArrow)) {
                    Movement(Vector2.right);
                }

                break;
        }
    }

    void Jump() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);

        // Out of Range Excpetion Check
        if(!hit) {
            return;
        }

        // Is used to make sure the player is touching the ground before being able to jump again
        if(hit.collider.tag == "Ground") {
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
