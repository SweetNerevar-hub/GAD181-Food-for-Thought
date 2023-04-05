using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BPAD {
    public class BPAD_Score : MonoBehaviour {

        public static int playerOnePoints = 0, playerTwoPoints = 0;

        public GameObject skull;
        public Transform[] skullSpawnPoints;

        // Start is called before the first frame update
        private void OnEnable() {
            EventManager.instance.DisplayWinner_BPAD += UpdatePlayerScore;
        }

        void UpdatePlayerScore(GameObject winner) {
            if(winner.name == "Player One" && playerOnePoints < 3) {
                playerOnePoints++;
                Instantiate(skull, new Vector2(skullSpawnPoints[0].transform.position.x + (25 * playerOnePoints), skullSpawnPoints[0].transform.position.y), Quaternion.identity, skullSpawnPoints[0]);
            }
            
            else if(winner.name == "Player Two" && playerTwoPoints < 3) {
                playerTwoPoints++;

                //Instantiate(skull, skullSpawnPoints[1].position, Quaternion.identity);
            }

            Debug.Log("P1: " + playerOnePoints);
            Debug.Log("P2: " + playerTwoPoints);
        }

        private void OnDisable() {
            EventManager.instance.DisplayWinner_BPAD -= UpdatePlayerScore;
        }
    }
}