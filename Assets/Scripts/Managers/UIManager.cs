using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    // Array of Scene UI's
    public GameObject[] UI;

    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    private void Start() {

        // When OnUpdateUI is called, call the UnloadExisitingUI function
        // This is to stop UI's from different scenes overlapping
        EventManager.instance.OnUpdateUI += UnloadExisitingUI;

        // This loads the Main Menu from the Master Scene when the game starts
        EventManager.instance.UpdateUI(1);
    }

    void UnloadExisitingUI(int sceneIndex) {

        // Unloads all UI on the Canvas
        foreach (GameObject element in UI) {
            element.SetActive(false);
        }

        LoadSceneUI(sceneIndex);
    }

    void LoadSceneUI(int sceneIndex) {

        // Loads the scene corresponding to the button clicked
        SceneManager.LoadScene(sceneIndex);

        // Loads the relevant UI of the scene just loaded
        // IMPORTANT! The order of the array must be the exact same order as the scene heirarchy
        UI[sceneIndex - 1].SetActive(true);

        Debug.Log("Loaded Scene: " + sceneIndex);
    }

    private void OnDisable() {
        EventManager.instance.OnUpdateUI -= UnloadExisitingUI;
    }
}
