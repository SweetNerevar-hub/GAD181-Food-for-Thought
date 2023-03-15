using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TopDownMovement : MonoBehaviour {

    Rigidbody rb;

    float h, v;

    public float speed;
    public bool playerOne;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();

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
                if (Input.GetKey(KeyCode.W)) {
                    Movement(Vector2.up);
                }

                else if (Input.GetKey(KeyCode.S)) {
                    Movement(Vector2.down);
                }

                else if (Input.GetKey(KeyCode.A)) {
                    Movement(Vector2.left);
                }

                else if (Input.GetKey(KeyCode.D)) {
                    Movement(Vector2.right);
                }

                break;

            case false:
                if (Input.GetKey(KeyCode.UpArrow)) {
                    Movement(Vector2.up);
                }

                else if (Input.GetKey(KeyCode.DownArrow)) {
                    Movement(Vector2.down);
                }

                else if (Input.GetKey(KeyCode.LeftArrow)) {
                    Movement(Vector2.left);
                }

                else if (Input.GetKey(KeyCode.RightArrow)) {
                    Movement(Vector2.right);
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
