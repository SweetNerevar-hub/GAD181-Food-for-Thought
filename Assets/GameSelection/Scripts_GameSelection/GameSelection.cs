using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelection : MonoBehaviour
{
    //SceneManagement script for game selection Menu.
    public void PlayChoppingBlock ()
    {
        EventManager.instance.UpdateUI(6);
    }

    public void PlayBananaPistolsAtDawn()
    {
        EventManager.instance.UpdateUI(5);
    }

    public void PlayFoodFallFrenzy()
    {
        EventManager.instance.UpdateUI(4);
    }

    public void PlaySmoothieTag()
    {
         //EventManager.instance.UpdateUI(7);
        SceneManager.LoadScene(7);
    }
    
    public void PlayWaterHazard()
    {
        EventManager.instance.UpdateUI(8);
    }

    /*
    public void PlayPacFood()
    {
        SceneManager.LoadScene();
    }
    
        public void PlayWaterHazard()
    {
        SceneManager.LoadScene();
    }
  
    */

}
