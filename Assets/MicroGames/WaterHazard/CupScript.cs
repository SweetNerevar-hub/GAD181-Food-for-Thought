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
        //Prevents requesting a variable outside the CupSprite list
        if(currentFrame >= 21)
        {
            currentFrame = 21;
        }

        //No matter how little water Player1 pours, the sprite will change to one 
        //with water in the cup
        if (cupCapacity > 0f && cupEmpty == true)
        {
            CupRenderer.sprite = CupSprite[1];
            currentFrame++;
            cupEmpty = false;
        }

        //Once the CupCapacity exceeds the range, the sprite changes and a new
        //range is made that the CupCapacity is within
        if(IsValueWithinRange(cupCapacity, bottomRange, topRange))
        {
            currentFrame++;
            CupRenderer.sprite = CupSprite[currentFrame];
            bottomRange += 10;
            topRange += 10;
        }    
    }
    //Determines the range that relates CupSprite and CupCapacity
    bool IsValueWithinRange(float value, float min, float max)
    {
        return value >= min && value <= max;
    }

}
