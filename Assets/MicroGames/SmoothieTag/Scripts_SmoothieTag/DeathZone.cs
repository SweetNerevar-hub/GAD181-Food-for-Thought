using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public GameObject playerBlood;
    private EndGameTimer timer;
    public AudioClip blender;
    private void Start()
    {
        timer = GameObject.Find("CountDown_Text").GetComponent<EndGameTimer>();

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = blender;
    }
    
    //script kills players on fall in zone.
    void OnTriggerEnter2D(Collider2D other)
    {

        if (!timer.PlayerOneWin())
        {
            timer.countDownDisplay.text = "P2 WIN";
            Destroy(other.gameObject);
            Invoke("GameOver", 3f);
            timer.countDownTime = 0;
        }
        else
        {
            timer.countDownDisplay.text = "P1 WIN";
            Destroy(other.gameObject);
            Invoke("GameOver", 3f);
            timer.countDownTime = 0;
        }


        timer.countDownTime = 1;
        GetComponent<AudioSource>().Play();
        timer.countDownDisplay.gameObject.SetActive(false);







        //timer.StartCoroutine(timer.CountDownToEnd());


    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
        Debug.Log("game end");
    }
    

}
