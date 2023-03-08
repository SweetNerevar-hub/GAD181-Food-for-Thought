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

        if (Input.GetKeyDown(KeyCode.P)) {
            LoadScene(3);
        }
    }

    void LoadScene(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }
}
