using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    public Sprite redTriangle;
    public Sprite greenTriangle;

    public SpriteRenderer render; 



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = redTriangle;
        }
        else
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = greenTriangle;
        }
    }
}
