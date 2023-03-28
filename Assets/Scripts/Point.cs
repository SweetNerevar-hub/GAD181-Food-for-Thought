using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePack : MonoBehaviour
{
    public int scoreValue = 0; //start health
    public float respawnTime = 5f; //token respawn time

    private float timer = -1f; //timer counts to 0, negative when off



    // Update is called once per frame
    private void Update()
    {
        if (timer >= 0f) //if timer is on
        {
            timer += Time.deltaTime; //counting timer per frame
            if (timer >= respawnTime) //if timer is more then or equal to respawn time
            {
                GetComponent<Collider>().enabled = true; //turns collider back on
                timer = -1; //timer resets
            }
        }
    }
    // when another collider hits this one
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true) //player collides with score token
        {
            SC_FPSController controller = other.GetComponent<SC_FPSController>(); //getting movement component from player rather then trigger
            if (controller != null) //if there is a movement component on the object
            {
                controller.AddScore(scoreValue); //adds score to overall score upon collision
                GetComponent<Collider>().enabled = false; //score token can only be interacted with once
                timer = 0; //turning on respawn time
            }
        }
    }
}

