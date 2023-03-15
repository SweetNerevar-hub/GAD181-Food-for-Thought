using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
         EventManager.instance.UpdateUI(7);
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
