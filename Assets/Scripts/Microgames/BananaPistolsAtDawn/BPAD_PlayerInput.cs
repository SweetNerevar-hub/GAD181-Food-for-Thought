using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BPAD {
    public class BPAD_PlayerInput : MonoBehaviour {

        public AudioSource audioSource;
        Animator animator;

        static bool inputEnabled, gameOver;
        bool correctInput, isWinner;
        int playerOne_RandomlyChosenKey, playerTwo_RandomlyChosenKey;

        string[] avaliableKeys = new string[] { "a", "d", "j", "l" };

        public bool playerOne;

        public GameObject bloodEffect;
        public Transform bloodSpawn;

        // Start is called before the first frame update
        void Start() {
            inputEnabled = false;
            gameOver = false;

            animator = GetComponent<Animator>();

            InputManager.instance.EnablePlayerInput_BPAD += EnablePlayerInput;
            EventManager.instance.DisplayWinner_BPAD += SpawnBloodEffect;
        }

        private void Update() {
            if (gameOver) {
                UpdateAnimations();
            }

            switch (inputEnabled) {
                case false:

                    return;

                // When the countdown timer has hit 0, and the player inputs have been enabled
                case true:
                    if (playerOne) {

                        // This was to fix a bug where any player can just hold both of the randomly assigned buttons at the same time, then quickly press their shoot button, removing the quick reflexes aspect
                        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) || !Input.GetKey(avaliableKeys[playerOne_RandomlyChosenKey])) {
                            correctInput = false;

                        }

                        // If the player presses the correct button
                        else if (Input.GetKey(avaliableKeys[playerOne_RandomlyChosenKey])) {
                            correctInput = true;
                        }

                        // Then presses their shoot button (Space), declare them the winner and turn off all player inputs
                        if(Input.GetKeyDown(KeyCode.Space) && correctInput) {
                            Winner();
                        }
                    }
                    
                    else {
                        if(Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.L) || !Input.GetKey(avaliableKeys[playerTwo_RandomlyChosenKey])) {
                            correctInput = false;
                        }

                        else if (Input.GetKey(avaliableKeys[playerTwo_RandomlyChosenKey])) {
                            correctInput = true;
                        }

                        if (Input.GetKeyDown(KeyCode.RightShift) && correctInput) {
                            Winner();
                        }
                    }

                    break;
            }
        }

        void EnablePlayerInput() {
            inputEnabled = true;

            // Randomly choose a directional button for each player
            playerOne_RandomlyChosenKey = Random.Range(0, 2);
            playerTwo_RandomlyChosenKey = Random.Range(2, 4);

            // Then display the needed inputs to each player
            EventManager.instance.BPAD_DisplayPlayerInput(playerOne_RandomlyChosenKey, playerTwo_RandomlyChosenKey, playerOne);
        }

        void Winner() {
            inputEnabled = false;
            isWinner = true;
            gameOver = true;

            // Gunshot sound effect
            audioSource.PlayOneShot(audioSource.clip);

            EventManager.instance.BPAD_DisplayWinner(gameObject);
        }

        void SpawnBloodEffect(GameObject winner) {

            // Spawn the blood effect for the loser
            if (gameObject != winner) {
                Instantiate(bloodEffect, bloodSpawn.position, Quaternion.identity, transform);
            }
        }

        void UpdateAnimations() {
            if (isWinner) animator.SetInteger("isWinner", 1);

            // Plays the death animation for the loser
            else animator.SetInteger("isWinner", -1);
        }

        private void OnDisable() {
            InputManager.instance.EnablePlayerInput_BPAD -= EnablePlayerInput;
            EventManager.instance.DisplayWinner_BPAD -= SpawnBloodEffect;
        }
    }
}

