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

    public SpriteRenderer p1BackgroundRenderer;
    public List<Sprite> p1BackgroundSprite;
    public int p1BackgroundFrame = 0;

    // Start is called before the first frame update
    void Start()
    {
        p1Renderer = GetComponent<SpriteRenderer>();
        p1CurrentFrame = 0;
        p1FirstInputDetected = false;
        p1Dummy = false;
        p1InputCount = 0;

        p1BackgroundRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        p1BackgroundFrame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MasterObjectScript masterObjectScript = GetComponentInParent<MasterObjectScript>();
        if (masterObjectScript.gameOver == false)
        {
            if (p1BackgroundFrame >= 4)
            {
                p1BackgroundFrame = 0;
            }

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

                    p1BackgroundRenderer.sprite = p1BackgroundSprite[p1BackgroundFrame];
                    p1BackgroundFrame++;
                }
                else if (Input.GetKeyDown(KeyCode.S) && p1FirstInputDetected)
                {
                    p1Renderer.sprite = p1Sprite[p1CurrentFrame];
                    p1CurrentFrame++;
                    p1InputCount++;
                    p1FirstInputDetected = false;
                    p1Dummy = false;
                    p1Chop.Play();

                    p1BackgroundRenderer.sprite = p1BackgroundSprite[p1BackgroundFrame];
                    p1BackgroundFrame++;
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

                    p1BackgroundRenderer.sprite = p1BackgroundSprite[p1BackgroundFrame];
                    p1BackgroundFrame++;
                }
                else if (Input.GetKeyDown(KeyCode.S) && p1FirstInputDetected)
                {
                    p1Renderer.sprite = p1Sprite[21];
                    p1InputCount++;
                    p1FirstInputDetected = false;
                    p1Dummy = false;
                    p1Chop.Play();

                    p1BackgroundRenderer.sprite = p1BackgroundSprite[p1BackgroundFrame];
                    p1BackgroundFrame++;
                }
            }
        }
        
    }
}
