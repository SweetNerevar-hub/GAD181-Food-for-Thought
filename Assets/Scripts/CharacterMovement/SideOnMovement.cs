using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideOnMovement : MonoBehaviour {

    float gravity, jumpForce, speed;

    // Start is called before the first frame update
    void Start() {
        InputManager.instance.Jump += Jump;
        InputManager.instance.MoveRight += MoveRight;
        InputManager.instance.MoveLeft += MoveLeft;

        gravity = 2f;
        jumpForce = 5f;
        speed = 5;
    }

    void Jump() {
        transform.Translate(Vector2.up * jumpForce * Time.deltaTime);
    }

    void MoveRight() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void MoveLeft() {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnDisable() {
        InputManager.instance.Jump -= Jump;
        InputManager.instance.MoveRight -= MoveRight;
        InputManager.instance.MoveLeft -= MoveLeft;
    }
}
