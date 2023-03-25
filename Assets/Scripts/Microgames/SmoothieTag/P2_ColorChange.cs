using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_ColorChange : MonoBehaviour
{



    public SpriteRenderer render;

    public bool isTagged;

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!isTagged)
            {
                render.color = Color.green;
                isTagged = true;
            }
            else
            {
                render.color = Color.red;
                isTagged = false;
            }
        }
    }
}
