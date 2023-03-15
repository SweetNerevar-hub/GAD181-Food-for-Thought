using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BPAD {
    public class BPAD_PlayerInput : MonoBehaviour {

        static bool inputEnabled;

        string[] avaliableKeys = new string[] { "a", "d", "j", "l" };

        public bool playerOne, correctInput;
        public int playerOne_RandomlyChosenKey, playerTwo_RandomlyChosenKey;

        // Start is called before the first frame update
        void Start() {
            inputEnabled = false;

            InputManager.instance.EnablePlayerInput_BPAD += EnablePlayerInput;
        }

        private void Update() {
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

            EventManager.instance.BPAD_DisplayPlayerInput(avaliableKeys[playerOne_RandomlyChosenKey], avaliableKeys[playerTwo_RandomlyChosenKey], playerOne);
        }

        void Winner() {
            inputEnabled = false;

            EventManager.instance.BPAD_DisplayWinner(gameObject.name);
        }

        private void OnDisable() {
            InputManager.instance.EnablePlayerInput_BPAD -= EnablePlayerInput;
        }
    }
}

