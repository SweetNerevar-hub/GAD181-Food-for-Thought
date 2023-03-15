using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideOnMovement : MonoBehaviour {

    Rigidbody rb;

    public bool playerOne;
    public float jumpForce, speed;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (playerOne) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                Jump();
            }

            if (Input.GetKey(KeyCode.A)) {
                MoveLeft();
            }

            else if (Input.GetKey(KeyCode.D)) {
                MoveRight();
            }
        }

        else {
            if (Input.GetKeyDown(KeyCode.RightShift)) {
                Jump();
            }

            if (Input.GetKey(KeyCode.LeftArrow)) {
                MoveLeft();
            }

            else if (Input.GetKey(KeyCode.RightArrow)) {
                MoveRight();
            }
        }
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

    void MoveRight() {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void MoveLeft() {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    private void OnTriggerEnter(Collider col) {
        if (col.GetComponent<Collider>().tag == "FFF_CollectableFood") {
            EventManager.instance.FFF_CollectFood(playerOne, col.gameObject);
        }
    }
}
