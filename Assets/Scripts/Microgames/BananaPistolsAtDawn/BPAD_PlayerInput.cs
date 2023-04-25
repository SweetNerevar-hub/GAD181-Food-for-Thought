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

                case true:
                    if (playerOne) {
                        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) || !Input.GetKey(avaliableKeys[playerOne_RandomlyChosenKey])) {
                            correctInput = false;

                        }

                        else if (Input.GetKey(avaliableKeys[playerOne_RandomlyChosenKey])) {
                            correctInput = true;
                        }

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

            playerOne_RandomlyChosenKey = Random.Range(0, 2);
            playerTwo_RandomlyChosenKey = Random.Range(2, 4);

            EventManager.instance.BPAD_DisplayPlayerInput(playerOne_RandomlyChosenKey, playerTwo_RandomlyChosenKey, playerOne);
        }

        void Winner() {
            inputEnabled = false;
            isWinner = true;
            gameOver = true;

            audioSource.PlayOneShot(audioSource.clip);

            EventManager.instance.BPAD_DisplayWinner(gameObject);

        }

        void SpawnBloodEffect(GameObject winner) {
            if (gameObject != winner) {
                Instantiate(bloodEffect, bloodSpawn.position, Quaternion.identity, transform);
            }
        }

        void UpdateAnimations() {
            if (isWinner) animator.SetInteger("isWinner", 1);

            else animator.SetInteger("isWinner", -1);
        }

        private void OnDisable() {
            InputManager.instance.EnablePlayerInput_BPAD -= EnablePlayerInput;
            EventManager.instance.DisplayWinner_BPAD -= SpawnBloodEffect;
        }
    }
}

