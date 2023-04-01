using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    // Array of Scene UI's
    public GameObject[] SceneUI;

    #region BPAD_Variables
    public Text[] BPAD_Text;
    public Image[] spriteDisplay;
    #endregion

    #region FoodFallFrenzy Variables
    public Text FFF_Header, Text_FFF_PlayerOneScore, Text_FFF_PlayerTwoScore;
    int FFF_playerOneScore, FFF_playerTwoScore;
    #endregion

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
        BPAD_Text[0].text = "Be Ready!";
    }

    #region BananaPistolsAtDawn Functions
    void BPAD_CallDrawAlert() {
        BPAD_Text[0].text = "DRAW!"; // Enable draw image/text
        InputManager.instance.BPAD_EnablePlayerInput();
    }

    void BPAD_DisplayPlayerInput(int playerOneInput, int playerTwoInput, bool playerOne) {
        if (playerOne) {
            spriteDisplay[playerOneInput].enabled = true;
            spriteDisplay[4].enabled = true;
        }

        else {
            spriteDisplay[playerTwoInput].enabled = true;
            spriteDisplay[5].enabled = true;
        }
    }

    void BPAD_DisplayWinner(GameObject winner) {
        BPAD_Text[0].text = "Winner: " + winner.name; // Enable winner

        foreach (Image item in spriteDisplay) {
            item.enabled = false;
        }

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
        foreach (Text items in BPAD_Text) {
            items.GetComponent<Text>().text = null;
        }

        FFF_Header.GetComponent<Text>().text = null;
        EventManager.instance.UpdateUI(3);
    }
}
