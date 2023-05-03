using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreditsScreen : MonoBehaviour {

    bool isCreditScreenOn;

    public GameObject creditScreen;

    private void Start() {
        isCreditScreenOn = false;
    }

    public void ToggleCreditsScreen() {
        if (isCreditScreenOn) {
            creditScreen.SetActive(false);
            isCreditScreenOn = false;

            transform.GetChild(0).GetComponent<TMP_Text>().SetText("Credits");
        }

        else {
            creditScreen.SetActive(true);
            isCreditScreenOn = true;

            transform.GetChild(0).GetComponent<TMP_Text>().SetText("Close");
        }
    }

    public void GoToLinkedWebsite(string url) {
        Application.OpenURL(url);
    }
}
