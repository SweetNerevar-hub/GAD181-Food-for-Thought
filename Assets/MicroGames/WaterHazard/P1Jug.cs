using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class P1Jug : MonoBehaviour
{
    public SpriteRenderer P1JugRenderer;
    public List<Sprite> P1JugSprite;

    private bool startAnimDummy = true;

    public bool turnOver = false;
    public bool finishedWaiting = false;


    void Start()
    {
        P1JugRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        if(Input.GetKey(KeyCode.D))
        {

            AnimateP1Jug();





        }
    }

    private void AnimateP1Jug()
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
    IEnumerator PauseUpdateLogic()
    {
        yield return new WaitForSeconds(0.2f);
        finishedWaiting = true;
    }
    

}
