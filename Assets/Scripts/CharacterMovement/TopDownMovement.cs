using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TopDownMovement : MonoBehaviour {

    float speed;

    // Start is called before the first frame update
    void Start() {
        InputManager.instance.MoveUp += MoveUp;
        InputManager.instance.MoveDown += MoveDown;
        InputManager.instance.MoveLeft += MoveLeft;
        InputManager.instance.MoveRight += MoveRight;

        speed = 5;
    }

    protected virtual void MoveUp() {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    protected virtual void MoveDown() {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    protected virtual void MoveLeft() {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    protected virtual void MoveRight() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
