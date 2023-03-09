using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TopDownMovement : MonoBehaviour {

    public float speed;

    // Start is called before the first frame update
    void Start() {
        InputManager.instance.MoveUp += MoveUp;
        InputManager.instance.MoveDown += MoveDown;
        InputManager.instance.MoveLeft += MoveLeft;
        InputManager.instance.MoveRight += MoveRight;
    }

    void MoveUp() {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void MoveDown() {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void MoveLeft() {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void MoveRight() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnDisable() {
        InputManager.instance.MoveUp -= MoveUp;
        InputManager.instance.MoveDown -= MoveDown;
        InputManager.instance.MoveLeft -= MoveLeft;
        InputManager.instance.MoveRight -= MoveRight;
    }
}
