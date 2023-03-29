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



    void Start()
    {
        P2JugRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //If Player2 presses Left during their turn, the jug sprite is updated
        //to show the water being poured, and the CupCapacity increases.
        WHMasterObject wHMasterObject = GetComponentInParent<WHMasterObject>();
        if (wHMasterObject.p2Turn == true && Input.GetKey(KeyCode.LeftArrow))
        {
            AnimateP2JugStart();
            GetComponentInParent<CupScript>().cupCapacity += 0.5f;
        }
        //Once Player2 releases Left, the sprite returns to normal and changes the 
        //bool being observed by the MasterObject that determines whether its 
        //Player2's turn.
        if (wHMasterObject.p2Turn == true && Input.GetKeyUp(KeyCode.LeftArrow))
        {
            P2JugRenderer.sprite = P2JugSprite[0];
            startAnimDummy = true;
            turnOver = true;
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
