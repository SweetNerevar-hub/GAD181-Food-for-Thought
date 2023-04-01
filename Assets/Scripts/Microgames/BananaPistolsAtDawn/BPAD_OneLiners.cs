using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BPAD_OneLiners : MonoBehaviour {

    public string[] oneLiners;
    public GameObject[] speechBubbles;

    // Start is called before the first frame update
    void Start() {
        oneLiners = new string[] {
            "I'm unbeetable",
            "Time to split"
        };
    }

    private void OnEnable() {
        EventManager.instance.DisplayWinner_BPAD += DisplayOneLiner;
    }

    void DisplayOneLiner(GameObject winner) {
        Transform speechBubblePosition = winner.transform.GetChild(0);

        int line = Random.Range(0, oneLiners.Length);

        if(winner.name == "Player One") {
            speechBubbles[0].GetComponent<Image>().enabled = true;
            speechBubbles[0].GetComponentInChildren<Text>().text = oneLiners[line];
        }

        else {
            speechBubbles[1].GetComponent<Image>().enabled = true;
            speechBubbles[1].GetComponentInChildren<Text>().text = oneLiners[line];
        }
        
        
    }

    private void OnDisable() {
        EventManager.instance.DisplayWinner_BPAD -= DisplayOneLiner;
    }
}
