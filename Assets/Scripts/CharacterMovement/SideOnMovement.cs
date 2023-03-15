using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideOnMovement : MonoBehaviour {

    Rigidbody rb;

    public bool playerOne;
    public float jumpForce, speed;
    float h;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        h = Input.GetAxisRaw("Horizontal");

        if (playerOne) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                Jump();
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
                Movement();
            }
        }

        else {
            if (Input.GetKeyDown(KeyCode.RightShift)) {
                Jump();
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
                Movement();
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

    void Movement() {
        rb.velocity = new Vector2(h * speed, rb.velocity.y);
    }

    private void OnTriggerEnter(Collider col) {
        if (col.GetComponent<Collider>().tag == "FFF_CollectableFood") {
            Debug.Log("Hit Food!");
            EventManager.instance.FFF_CollectFood(playerOne);
        }
    }
}
