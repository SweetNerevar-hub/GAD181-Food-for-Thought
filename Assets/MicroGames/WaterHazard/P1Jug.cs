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
    public bool p1Turn = false;


    void Start()
    {
        P1JugRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        WHMasterObject wHMasterObject = GetComponentInParent<WHMasterObject>();
        if (wHMasterObject.p1Turn == true && Input.GetKey(KeyCode.D))
        {
            AnimateP1JugStart();
            GetComponentInParent<CupScript>().cupCapacity += 0.5f;
        }
        if (wHMasterObject.p1Turn == true && Input.GetKeyUp(KeyCode.D))
        {
            P1JugRenderer.sprite = P1JugSprite[0];
            turnOver = true;
        }
    }

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
    /*private void AnimateP1JugEnd()
    {
        P1JugRenderer.sprite = P1JugSprite[1];
        StartCoroutine(PauseUpdateLogic());
        if (finishedWaiting == true)
        {
            P1JugRenderer.sprite = P1JugSprite[0];
            finishedWaiting = false;
            startAnimDummy = false;
        }
    }*/
    IEnumerator PauseUpdateLogic()
    {
        yield return new WaitForSeconds(0.2f);
        finishedWaiting = true;
    }
    
}
