using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour {

    public static EventManager instance;

    // Start is called before the first frame update
    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    public event Action<int> OnUpdateUI;

    public void UpdateUI(int sceneIndex) {
        OnUpdateUI?.Invoke(sceneIndex);
    }
}
