using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    // Array of Scene UI's
    public GameObject[] SceneUI;

    public Text BPAD_Header, BPAD_PlayerOneInput, BPAD_PlayerTwoInput;
    public Text FFF_Header, Text_FFF_PlayerOneScore, Text_FFF_PlayerTwoScore;

    int FFF_playerOneScore, FFF_playerTwoScore;

    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    private void Start() {

        // When OnUpdateUI is called, call the UnloadExisitingUI function
        // This is to stop UI's from different scenes overlapping
        EventManager.instance.OnUpdateUI += UnloadExisitingUI;

        // This loads the Main Menu from the Master Scene when the game starts
        EventManager.instance.UpdateUI(1);

        // UI Events for Banana Pistols at Dawn
        EventManager.instance.DisplayPlayerInput_BPAD += BPAD_DisplayPlayerInput;
        EventManager.instance.DisplayAlert_BPAD += BPAD_CallDrawAlert;
        EventManager.instance.DisplayWinner_BPAD += BPAD_DisplayWinner;

        // UI Events for Food Fall Frenzy
        EventManager.instance.OnCollectFood_FFF += FFF_UpdatePlayerScore;
        EventManager.instance.DisplayWinner_FFF += FFF_DisplayWinner;
    }

    void UnloadExisitingUI(int sceneIndex) {

        // Unloads all UI on the Canvas
        foreach (GameObject element in SceneUI) {
            element.SetActive(false);
        }

        LoadSceneUI(sceneIndex);
    }

    void LoadSceneUI(int sceneIndex) {

        // Loads the scene corresponding to the button clicked
        SceneManager.LoadScene(sceneIndex);

        // Loads the relevant UI of the scene just loaded
        // IMPORTANT!!! The order of the array must be the exact same order as the scene heirarchy
        SceneUI[sceneIndex - 1].SetActive(true);

        Debug.Log("Loaded Scene: " + sceneIndex);
    }

    #region BananaPistolsAtDawn Functions
    void BPAD_CallDrawAlert() {
        BPAD_Header.gameObject.SetActive(true);

        BPAD_Header.GetComponent<Text>().text = "DRAW!"; // Enable draw image/text
        InputManager.instance.BPAD_EnablePlayerInput();
    }

    void BPAD_DisplayPlayerInput(string playerOneInput, string playerTwoInput, bool playerOne) {
        if(playerOne) BPAD_PlayerOneInput.GetComponent<Text>().text = playerOneInput + " + Space";
        else BPAD_PlayerTwoInput.GetComponent<Text>().text = playerTwoInput + " + RightShift";
    }

    void BPAD_DisplayWinner(string winnerName) {
        BPAD_Header.GetComponent<Text>().text = "Winner: " + winnerName; // Enable winner
        BPAD_PlayerOneInput.GetComponent<Text>().text = null;
        BPAD_PlayerTwoInput.GetComponent<Text>().text = null;

        Invoke("BackToMenu", 5f);
    }
    #endregion

    #region FoodFallFrenzy Functions
    void FFF_UpdatePlayerScore(bool playerOne, GameObject food) {
        if (playerOne) {
            FFF_playerOneScore++;
            Text_FFF_PlayerOneScore.GetComponent<Text>().text = "Player 1 Score: " + FFF_playerOneScore;
        }

        else {
            FFF_playerTwoScore++;
            Text_FFF_PlayerTwoScore.GetComponent<Text>().text = "Player 2 Score: " + FFF_playerTwoScore;
        }
    }

    void FFF_DisplayWinner() {
        if(FFF_playerOneScore > FFF_playerTwoScore) {
            FFF_Header.GetComponent<Text>().text = "Winner: Player One";
        }

        else if(FFF_playerOneScore < FFF_playerTwoScore){
            FFF_Header.GetComponent<Text>().text = "Winner: Player Two";
        }

        else {
            FFF_Header.GetComponent<Text>().text = "It's a Tie!";
        }

        Invoke("BackToMenu", 5f);
    }
    #endregion

    void BackToMenu() {
        BPAD_Header.GetComponent<Text>().text = null;
        FFF_Header.GetComponent<Text>().text = null;
        EventManager.instance.UpdateUI(3);
    }
}
