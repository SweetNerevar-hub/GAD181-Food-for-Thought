using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour {

    public static InputManager instance;

    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    // Input Events for Banana Pistols at Dawn
    public event Action EnablePlayerInput_BPAD;


    public void BPAD_EnablePlayerInput() {
        EnablePlayerInput_BPAD?.Invoke();
    }
}

#region Old Movement Code

    /*
    public event Action Jump;
    public event Action MoveUp;
    public event Action MoveDown;
    public event Action MoveLeft;
    public event Action MoveRight;
    */


    /*
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightShift)) {
            Jump?.Invoke();
        }

        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            MoveUp?.Invoke();
        }

        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            MoveDown?.Invoke();
        }

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            MoveLeft?.Invoke();
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            MoveRight?.Invoke();
        }
    }
    */

#endregion
