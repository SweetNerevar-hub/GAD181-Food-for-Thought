using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BPAD {
    public class BPAD_OneLiners : MonoBehaviour {

        public string[] oneLiners;
        public GameObject[] speechBubbles;

        // Start is called before the first frame update
        void Start() {
            oneLiners = new string[] {
            "I'm unbeetable",
            "Time to split",
            "You're leeking",
            "I'm berry disappointed in your aim",
            "Don't be so melon-coli"
        };
        }

        private void OnEnable() {
            EventManager.instance.DisplayWinner_BPAD += DisplayOneLiner;

            // When BPAD begins, disable the speech bubble images
            HideSpeechBubble();
        }

        void DisplayOneLiner(GameObject winner) {

            // Get the speech bubble object relative to the winner
            Transform speechBubblePosition = winner.transform.GetChild(0);

            // Randomly chooses a one-liner
            int line = Random.Range(0, oneLiners.Length);

            if (winner.name == "Player One") {

                // Enable the speech bubble and set the text to the one-liner
                speechBubbles[0].GetComponent<Image>().enabled = true;
                speechBubbles[0].GetComponentInChildren<Text>().text = oneLiners[line];
            }
            
            else {
                speechBubbles[1].GetComponent<Image>().enabled = true;
                speechBubbles[1].GetComponentInChildren<Text>().text = oneLiners[line];
            }

            Invoke("HideSpeechBubble", 5f);
        }

        void HideSpeechBubble() {
            speechBubbles[0].GetComponent<Image>().enabled = false;
            speechBubbles[1].GetComponent<Image>().enabled = false;
        }

        private void OnDisable() {
            EventManager.instance.DisplayWinner_BPAD -= DisplayOneLiner;
        }
    }
}