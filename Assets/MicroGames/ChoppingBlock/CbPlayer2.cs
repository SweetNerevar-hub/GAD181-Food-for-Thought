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
    // Start is called before the first frame update
    void Start()
    {
        p2Renderer= GetComponent<SpriteRenderer>();
        p2CurrentFrame = 0;
        p2FirstInputDetected = false;
        p2Dummy = false;
        p2InputCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MasterObjectScript masterObjectScript = GetComponentInParent<MasterObjectScript>();
        if (masterObjectScript.gameOver == false)
        {
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
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && p2FirstInputDetected)
                {
                    p2Renderer.sprite = p2Sprite[p2CurrentFrame];
                    p2CurrentFrame++;
                    p2InputCount++;
                    p2FirstInputDetected = false;
                    p2Dummy = false;
                    p2Chop.Play();
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
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && p2FirstInputDetected)
                {
                    p2Renderer.sprite = p2Sprite[21];

                    p2InputCount++;
                    p2FirstInputDetected = false;
                    p2Dummy = false;
                    p2Chop.Play();
                }
            }
        }

    }
}
