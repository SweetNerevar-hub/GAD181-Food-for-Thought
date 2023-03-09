using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public GameObject[] UI;

    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    private void Start() {
        EventManager.instance.OnUpdateUI += UnloadExisitingUI;
        EventManager.instance.UpdateUI(1);
    }

    void UnloadExisitingUI(int sceneIndex) {
        if (!UI[sceneIndex - 1]) {
            Debug.Log("Went over array count");
            return;
        }

        foreach (GameObject element in UI) {
            element.SetActive(false);
        }

        LoadSceneUI(sceneIndex);
    }

    void LoadSceneUI(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);

        UI[sceneIndex - 1].SetActive(true);

        Debug.Log("Loaded Scene: " + sceneIndex);
    }

    private void OnDisable() {
        EventManager.instance.OnUpdateUI -= UnloadExisitingUI;
    }
}
