using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideOnMovement : MonoBehaviour {

    Rigidbody rb;

    public float jumpForce, speed;
    float h;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();

        InputManager.instance.Jump += Jump;
        InputManager.instance.MoveRight += Movement;
        InputManager.instance.MoveLeft += Movement;
    }

    private void Update() {
        h = Input.GetAxisRaw("Horizontal");
    }

    void Jump() {
        RaycastHit hit;

        // Is used to make sure the player is touching the ground before being able to jump again
        if(Physics.Raycast(transform.position, Vector2.down, out hit, 1f)) {
            if(hit.collider.tag == "Ground") {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            }
        }
    }

    void Movement() {
        rb.velocity = new Vector2(h * speed, rb.velocity.y);
    }

    private void OnDisable() {

        // Is called when the script is disabled
        // Stop conflicts between the switching from top-down to side-on movement
        InputManager.instance.Jump -= Jump;
        InputManager.instance.MoveRight -= Movement;
        InputManager.instance.MoveLeft -= Movement;
    }
}
