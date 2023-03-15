using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyKeyInput : MonoBehaviour
{
       //Detects if any key has been pressed.
    void Update()
    {
        if (Input.anyKey)
        {
            EventManager.instance.UpdateUI(3);
        }
    }
}
