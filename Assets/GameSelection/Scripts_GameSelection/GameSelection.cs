using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelection : MonoBehaviour
{
    //SceneManagement script for game selection Menu.
    public void PlayChoppingBlock ()
    {
        EventManager.instance.UpdateUI(4);
    }
    public void PlayFoodFallFrenzy()
    {
        EventManager.instance.UpdateUI(5);
    }

    /*
    public void PlayPacFood()
    {
        SceneManager.LoadScene();
    }
    public void PlayBananaPistolsAtDawn()
    {
        SceneManager.LoadScene();
    }
        public void PlayWaterHazard()
    {
        SceneManager.LoadScene();
    }
        public void PlaySmoothieTag()
    {
        SceneManager.LoadScene();
    }
    */

}
