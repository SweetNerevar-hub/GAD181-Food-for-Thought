using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CbPlayer1 : MonoBehaviour
{
    public SpriteRenderer p1Renderer;
    public List<Sprite> p1Sprite;
    public int p1CurrentFrame = 0;
    public bool p1FirstInputDetected = false;
    public bool p1Dummy = false;
    public int p1InputCount = 0;
    public AudioSource p1Chop;
    // Start is called before the first frame update
    void Start()
    {
        p1Renderer = GetComponent<SpriteRenderer>();
        p1CurrentFrame = 0;
        p1FirstInputDetected = false;
        p1Dummy = false;
        p1InputCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MasterObjectScript masterObjectScript = GetComponentInParent<MasterObjectScript>();
        if (masterObjectScript.gameOver == false)
        {
            if (p1InputCount <= 10)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    p1FirstInputDetected = true;
                }
                else if (p1FirstInputDetected == true && p1Dummy == false)
                {
                    p1Renderer.sprite = p1Sprite[p1CurrentFrame];
                    p1CurrentFrame++;
                    p1Dummy = true;
                }
                else if (Input.GetKeyDown(KeyCode.S) && p1FirstInputDetected)
                {
                    p1Renderer.sprite = p1Sprite[p1CurrentFrame];
                    p1CurrentFrame++;
                    p1InputCount++;
                    p1FirstInputDetected = false;
                    p1Dummy = false;
                    p1Chop.Play();
                    
                }
            }
            if (p1InputCount > 10)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    p1FirstInputDetected = true;
                }
                else if (p1FirstInputDetected == true && p1Dummy == false)
                {
                    p1Renderer.sprite = p1Sprite[20];
                    p1Dummy = true;
                }
                else if (Input.GetKeyDown(KeyCode.S) && p1FirstInputDetected)
                {
                    p1Renderer.sprite = p1Sprite[21];
                    p1InputCount++;
                    p1FirstInputDetected = false;
                    p1Dummy = false;
                    p1Chop.Play();
                }
            }
        }
        
    }
}
