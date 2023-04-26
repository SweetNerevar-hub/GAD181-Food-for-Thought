using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.LowLevel;

public class Blender : MonoBehaviour
{
    public GameObject playerBlood;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(playerBlood, transform.position, Quaternion.identity);
        }
    }

}

