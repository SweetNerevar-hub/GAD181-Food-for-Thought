using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CbPlayer2 : MonoBehaviour
{
    public SpriteRenderer p2Renderer;
    public List<Sprite> p2Sprite;
    public int p2CurrentFrame = 0;
    public bool p2FirstInputDetected = false;
    public bool p2Dummy = false;
    public int p2InputCount = 0;
    public AudioSource p2Chop;

    public SpriteRenderer p2BackgroundRenderer;
    public List<Sprite> p2BackgroundSprite;
    public int p2BackgroundFrame = 0;
    // Start is called before the first frame update
    void Start()
    {
        p2Renderer= GetComponent<SpriteRenderer>();
        p2CurrentFrame = 0;
        p2FirstInputDetected = false;
        p2Dummy = false;
        p2InputCount = 0;

        p2BackgroundRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        p2BackgroundFrame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        MasterObjectScript masterObjectScript = GetComponentInParent<MasterObjectScript>();
        if (masterObjectScript.gameOver == false)
        {
            if(p2BackgroundFrame >= 4)
            {
                p2BackgroundFrame = 0;
            }

            if (p2InputCount <= 10)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    p2FirstInputDetected = true;
                }
                else if (p2FirstInputDetected == true && p2Dummy == false)
                {
                    p2Renderer.sprite = p2Sprite[p2CurrentFrame];
                    p2CurrentFrame++;
                    p2Dummy = true;

                    p2BackgroundRenderer.sprite = p2BackgroundSprite[p2BackgroundFrame];
                    p2BackgroundFrame++;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && p2FirstInputDetected)
                {
                    p2Renderer.sprite = p2Sprite[p2CurrentFrame];
                    p2CurrentFrame++;
                    p2InputCount++;
                    p2FirstInputDetected = false;
                    p2Dummy = false;
                    p2Chop.Play();

                    p2BackgroundRenderer.sprite = p2BackgroundSprite[p2BackgroundFrame];
                    p2BackgroundFrame++;
                }
            }
            if (p2InputCount > 10)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    p2FirstInputDetected = true;
                }
                else if (p2FirstInputDetected == true && p2Dummy == false)
                {
                    p2Renderer.sprite = p2Sprite[20];
                    p2Dummy = true;

                    p2BackgroundRenderer.sprite = p2BackgroundSprite[p2BackgroundFrame];
                    p2BackgroundFrame++;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && p2FirstInputDetected)
                {
                    p2Renderer.sprite = p2Sprite[21];

                    p2InputCount++;
                    p2FirstInputDetected = false;
                    p2Dummy = false;
                    p2Chop.Play();

                    p2BackgroundRenderer.sprite = p2BackgroundSprite[p2BackgroundFrame];
                    p2BackgroundFrame++;
                }
            }
        }

    }
}
