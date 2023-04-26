using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Jug : MonoBehaviour
{
    public SpriteRenderer P1JugRenderer;
    public List<Sprite> P1JugSprite;

    private bool startAnimDummy = true;

    public bool turnOver = false;
    public bool finishedWaiting = false;
    private float cupFillSpeed = 150f;

    public AudioSource audioSource;
    public AudioClip p1Pour;
    public bool playAudio = false;


    void Start()
    {
        P1JugRenderer = GetComponent<SpriteRenderer>();
        
        
    }

    void Update()
    {
        if(GetComponentInParent<CupScript>().currentFrame >= 15)
        {
            cupFillSpeed = 50f;
        }
        //If Player1 presses D during their turn, the jug sprite is updated
        //to show the water being poured, and the CupCapacity increases.
        WHMasterObject wHMasterObject = GetComponentInParent<WHMasterObject>();
        if (wHMasterObject.p1Turn == true && Input.GetKey(KeyCode.D))
        {
            
            AnimateP1JugStart();
            GetComponentInParent<CupScript>().cupCapacity += cupFillSpeed *Time.deltaTime;
            playAudio = true;
            
            
        }
        //Once Player 1 releases D, the sprite returns to normal and changes the 
        //bool being observed by the MasterObject that determines whether its 
        //Player1's turn.
        if (wHMasterObject.p1Turn == true && Input.GetKeyUp(KeyCode.D))
        {
            P1JugRenderer.sprite = P1JugSprite[0];
            startAnimDummy = true;
            turnOver = true;
            playAudio = false;
            
        }
        if(playAudio == true && !audioSource.isPlaying)
        {
            audioSource.volume *= 3;
            audioSource.PlayOneShot(p1Pour);
            Debug.Log("audio start");
        }
        else if(!playAudio)
        {
            audioSource.Stop();
        }
    }

    //Changes the sprite of the Jug to show the water being poured
    private void AnimateP1JugStart()
    {
        if(startAnimDummy == true)
        {
            P1JugRenderer.sprite = P1JugSprite[1];
            StartCoroutine(PauseUpdateLogic());
            if (finishedWaiting == true)
            {
                P1JugRenderer.sprite = P1JugSprite[2];
                finishedWaiting = false;
                startAnimDummy = false;
            }
        }
    }

    //Creates delay as the jug transitions between sprites
    IEnumerator PauseUpdateLogic()
    {
        yield return new WaitForSeconds(0.2f);
        finishedWaiting = true;
    }

}
