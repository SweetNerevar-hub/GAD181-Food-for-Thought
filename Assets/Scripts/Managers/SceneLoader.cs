using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void ChangeScene(int sceneIndex) {
        EventManager.instance.UpdateUI(sceneIndex);
    }
}
