using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{



  public  SpriteRenderer render;

    public bool isTagged;

    private void Start()
    {
       // render = GetComponentInChildren<SpriteRenderer>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!isTagged)
            {
                render.color = Color.red;
                isTagged = true;
                Debug.Log("Tagged");
            }
            else
            {
                render.color = Color.green;
                isTagged = false;
            }
        }
    }
}
