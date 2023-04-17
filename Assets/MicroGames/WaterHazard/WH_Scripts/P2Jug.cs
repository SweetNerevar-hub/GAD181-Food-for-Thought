using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Jug : MonoBehaviour
{
    public SpriteRenderer P2JugRenderer;
    public List<Sprite> P2JugSprite;

    private bool startAnimDummy = true;

    public bool turnOver = false;
    public bool finishedWaiting = false;
    private float cupFillSpeed = 150f;

    public AudioSource audioSource;
    public AudioClip p2Pour;
    public bool playAudio = false;

    void Start()
    {
        P2JugRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (GetComponentInParent<CupScript>().currentFrame >= 15)
        {
            cupFillSpeed = 50f;
        }
        //If Player2 presses Left during their turn, the jug sprite is updated
        //to show the water being poured, and the CupCapacity increases.
        WHMasterObject wHMasterObject = GetComponentInParent<WHMasterObject>();
        if (wHMasterObject.p2Turn == true && Input.GetKey(KeyCode.LeftArrow))
        {
            AnimateP2JugStart();
            GetComponentInParent<CupScript>().cupCapacity += cupFillSpeed * Time.deltaTime;
            playAudio = true;
        }
        //Once Player2 releases Left, the sprite returns to normal and changes the 
        //bool being observed by the MasterObject that determines whether its 
        //Player2's turn.
        if (wHMasterObject.p2Turn == true && Input.GetKeyUp(KeyCode.LeftArrow))
        {
            P2JugRenderer.sprite = P2JugSprite[0];
            startAnimDummy = true;
            turnOver = true;
            playAudio = false;
        }
        if (playAudio == true)
        {
            audioSource.PlayOneShot(p2Pour);
        }
        else if (!playAudio)
        {
            audioSource.Stop();
        }
    }

    //Changes the sprite of the Jug to show the water being poured
    private void AnimateP2JugStart()
    {
        if (startAnimDummy == true)
        {
            P2JugRenderer.sprite = P2JugSprite[1];
            StartCoroutine(PauseUpdateLogic());
            if (finishedWaiting == true)
            {
                P2JugRenderer.sprite = P2JugSprite[2];
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
