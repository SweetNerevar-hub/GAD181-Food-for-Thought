using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    private void Start() {
        SceneManager.LoadScene(1);

        EventManager.instance.OnUpdateUI += MainMenuUI;
    }

    void MainMenuUI(int sceneIndex) {
        Debug.Log("Loaded Scene: " + sceneIndex);
    }

    private void OnDisable() {
        EventManager.instance.OnUpdateUI -= MainMenuUI;
    }
}
