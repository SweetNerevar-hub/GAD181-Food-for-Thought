using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupScript : MonoBehaviour
{
    public SpriteRenderer CupRenderer;
    public List<Sprite> CupSprite;

    public int currentFrame = 0;
    public float cupCapacity = 0f;
    public bool cupEmpty = true;

    float bottomRange = 10f;
    float topRange = 20f;

    

    void Start()
    {
        CupRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (cupCapacity > 0f && cupEmpty == true)
        {
            CupRenderer.sprite = CupSprite[1];
            currentFrame++;
            cupEmpty = false;
        }

        if(IsValueWithinRange(cupCapacity, bottomRange, topRange))
        {
            currentFrame++;
            CupRenderer.sprite = CupSprite[currentFrame];
            bottomRange += 10;
            topRange += 10;
        }    
    }

    bool IsValueWithinRange(float value, float min, float max)
    {
        return value >= min && value <= max;
    }

}
