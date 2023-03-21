using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    //script kills players on fall in zone.
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }

}
