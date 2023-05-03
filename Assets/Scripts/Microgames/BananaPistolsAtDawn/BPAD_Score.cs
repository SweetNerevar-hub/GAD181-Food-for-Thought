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

                // This is used to make the skull icon show up in the same spot across many different screen sizes
                float padding = Screen.width / (skull.GetComponent<RectTransform>().rect.width / 2);

                // Spawn the skull at the location specific to the winning player
                Vector2 skullPosition = new Vector2(skullSpawnPoints[0].position.x + (padding * playerOnePoints), skullSpawnPoints[0].position.y);
                Instantiate(skull, skullPosition, Quaternion.identity, skullSpawnPoints[0]);
            }
            
            else if(winner.name == "Player Two" && playerTwoPoints < 3) {
                playerTwoPoints++;

                float padding = Screen.width / (skull.GetComponent<RectTransform>().rect.width / 2);

                Vector2 skullPosition = new Vector2(skullSpawnPoints[1].position.x + (padding * playerTwoPoints), skullSpawnPoints[1].position.y);
                Instantiate(skull, skullPosition, Quaternion.identity, skullSpawnPoints[1]);
            }
        }

        private void OnDisable() {
            EventManager.instance.DisplayWinner_BPAD -= UpdatePlayerScore;
        }
    }
}