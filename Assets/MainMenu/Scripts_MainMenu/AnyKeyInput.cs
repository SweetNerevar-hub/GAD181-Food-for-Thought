using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class AnyKeyInput : MonoBehaviour
{ 
    
    // This solves a bug that occured when the player moved from the Main Menu to the Game Selection scene before the screen had fully faded in
    // Since the fading in and out of not only the audio, but also the scene is depended on the screen fading fully in and out
    // Also the changing of music from scene to scene is dependent on scenes finishing their fading
    // So I disable this script for 2 seconds, this stops the player from changing scenes too soon
    // Then the Invoke is called after the 2 seconds (which surprised me, I thought that it wouldn't call since the script is disabled. But I guess Invokes work independently from the script at runtime)
    // The script is then re-enabled, and the player is able to press any key to move onto the Game Selection scene
    private void Start() {
        Invoke("EnableInput", 2);
        this.enabled = false;
    }

    void EnableInput() {
        this.enabled = true;
    }

    //Code by Kelecia
    //Detects if any key has been pressed.
    void Update()
    {
        if (Input.anyKeyDown)
        {
            EventManager.instance.UpdateUI(2);
           // SceneManager.LoadScene(3);
        }
    }
}
