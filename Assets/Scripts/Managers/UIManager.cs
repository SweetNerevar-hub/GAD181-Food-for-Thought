using BPAD;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    // Array of Scene UI's
    public GameObject[] SceneUI;

    int currentScene;

    #region BPAD_Variables
    public Text[] BPAD_Text; // 0 = Header, 1 = Player One Speech, 2 = Player 2 Speech
    public Text[] playerPointsText;
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

        #region Banana Pistol at Dawn Events
        EventManager.instance.DisplayPlayerInput_BPAD += BPAD_DisplayPlayerInput;
        EventManager.instance.DisplayAlert_BPAD += BPAD_CallDrawAlert;
        EventManager.instance.DisplayWinner_BPAD += BPAD_DisplayWinner;
        #endregion

        #region Food Fall Frenzy Events
        EventManager.instance.OnCollectFood_FFF += FFF_UpdatePlayerScore;
        EventManager.instance.DisplayWinner_FFF += FFF_DisplayWinner;
        #endregion
    }

    void UnloadExisitingUI(int sceneIndex) {

        // Unloads all UI on the Canvas
        foreach (GameObject element in SceneUI) {
            element.SetActive(false);
        }

        LoadSceneUI(sceneIndex);
        currentScene = sceneIndex;
    }

    void LoadSceneUI(int sceneIndex) {

        // Loads the scene corresponding to the button clicked
        SceneManager.LoadScene(sceneIndex);

        // Loads the relevant UI of the scene just loaded
        // IMPORTANT!!! The order of the array must be the exact same order as the scene heirarchy
        SceneUI[sceneIndex - 1].SetActive(true);

        // If Banana Pistols at Dawn is Loaded, then reset the games UI and start fresh
        if (sceneIndex == 5) BPAD_ResetUI();
    }

    #region BananaPistolsAtDawn Functions
    void BPAD_ResetUI() {
        foreach (Image item in spriteDisplay) {
            item.enabled = false;
        }

        foreach (Text items in BPAD_Text) {
            items.GetComponent<Text>().text = null;
        }

        BPAD_Text[0].text = "Be Ready!";
    }

    void BPAD_CallDrawAlert() {
        BPAD_Text[0].text = "DRAW!";
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
        BPAD_Text[0].text = "Point to " + winner.name;

        StartCoroutine(BPAD_CheckForWinner(winner));
    }

    IEnumerator BPAD_CheckForWinner(GameObject winner) {

        // This is to allow the BPAD_Score script to update the players score before checking to see if any player has won
        yield return new WaitForSeconds(0.01f);

        if (BPAD.BPAD_Score.playerOnePoints == 3 || BPAD.BPAD_Score.playerTwoPoints == 3) {
            BPAD_Text[0].text = "Winner: " + winner.name;

            BPAD.BPAD_Score.playerOnePoints = 0;
            BPAD.BPAD_Score.playerTwoPoints = 0;

            Invoke("DestroySkulls", 5f);
            Invoke("BackToMenu", 5f); 
        }
        
        else {
            Invoke("BPAD_ResetGame", 5f);
        }
    }

    void DestroySkulls() {
        GameObject[] skulls = GameObject.FindGameObjectsWithTag("BPAD_Skull");

        foreach (GameObject item in skulls) {
            Destroy(item);
        }
    }

    void BPAD_ResetGame() {
        BPAD_ResetUI();
        SceneManager.LoadScene(currentScene);
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
        // Move to LoadSceneUI() -> FFF_Header.GetComponent<Text>().text = null;

        EventManager.instance.UpdateUI(3);
    }
}
