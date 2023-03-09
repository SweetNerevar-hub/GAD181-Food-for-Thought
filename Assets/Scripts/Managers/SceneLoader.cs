using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    // Is called when a Button that changes the scene is clicked
    public void ChangeScene(int sceneIndex) {
        EventManager.instance.UpdateUI(sceneIndex);
    }
}
