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

    private void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            EventManager.instance.UpdateUI(2);
        }
        
        else if (Input.GetKeyDown(KeyCode.O)) {
            EventManager.instance.UpdateUI(3);
        }
    }
}

#region Old Movement Code

    /*
    public event Action Jump;
    public event Action MoveUp;
    public event Action MoveDown;
    public event Action MoveLeft;
    public event Action MoveRight;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump?.Invoke();
        }

        else if (Input.GetKey(KeyCode.W)) {
            MoveUp?.Invoke();
        }

        else if (Input.GetKey(KeyCode.S)) {
            MoveDown?.Invoke();
        }

        else if (Input.GetKey(KeyCode.A)) {
            MoveLeft?.Invoke();
        }

        else if (Input.GetKey(KeyCode.D)) {
            MoveRight?.Invoke();
        }
    }
    */

#endregion
