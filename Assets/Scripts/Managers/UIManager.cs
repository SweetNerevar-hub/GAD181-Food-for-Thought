using BPAD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    // Array of Scene UI's
    public GameObject[] SceneUI;
    public GameObject fadeScreen;
    public GameObject eventSystem;

    int currentScene;
    float waitTime = 0.01f;

    #region BPAD_Variables
    public Text[] BPAD_Text; // 0 = Header, 1 = Player One Speech, 2 = Player 2 Speech
    public Image[] spriteDisplay;
    #endregion

    #region Food Fall Frenzy Variables
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

        // When the player trigger a scene change, call the FadeOut function
        // Which will then lead into the FadeIn function, and then the LoadSceneUI function
        EventManager.instance.OnUpdateUI += CallFadeOut;
        EventManager.instance.OnScreenFade += CallFadeIn;

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

    void LoadSceneUI() {

        // Unloads all UI on the Canvas so as not to overlap with other scene's UI's
        foreach (GameObject element in SceneUI) {
            element.SetActive(false);
        }

        // Loads the scene corresponding the sceneIndex variable which is stored when the OnUpdateUI event is triggered
        SceneManager.LoadScene(currentScene);

        // Loads the relevant UI of the scene just loaded
        // IMPORTANT!!! The order of the array must be the exact same order as the scene heirarchy
        SceneUI[currentScene - 1].SetActive(true);

        // If Food Fall Frenzy is Loaded, then reset the game UI
        // Call the event that triggers to play the video tutorial
        if(currentScene == 3) {
            FFF_Header.GetComponent<Text>().text = null;
            EventManager.instance.PlayVideoTutorial(currentScene);
        }

        // If Banana Pistols at Dawn is Loaded, then reset the games UI and start fresh
        if (currentScene == 4) {
            BPAD_ResetUI();
            EventManager.instance.PlayVideoTutorial(currentScene);
        }
    }

    #region BananaPistolsAtDawn Functions

    // This resets the header text, the input display, and the one liners text and speech bubble image
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

    // Displays the required input for each player
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

    // This is to allow the BPAD_Score script to update the players score before checking to see if any player has won
    IEnumerator BPAD_CheckForWinner(GameObject winner) {      
        yield return new WaitForSeconds(0.01f);

        // If a player has won the whole game
        // Display that winner's name. then begin the reseting values, and removing UI elements
        if (BPAD.BPAD_Score.playerOnePoints == 3 || BPAD.BPAD_Score.playerTwoPoints == 3) {
            BPAD_Text[0].text = "Winner: " + winner.name;

            BPAD.BPAD_Score.playerOnePoints = 0;
            BPAD.BPAD_Score.playerTwoPoints = 0;

            Invoke("DestroySkulls", 5f);
            Invoke("BackToMenu", 5f); 
        }
        
        else {

            // If no player has won the game
            // Reset the scene, keeping all the important UI elements
            Invoke("BPAD_ResetGame", 5f);
        }
    }

    // Triggers at the end of the game
    // Removes the skull images so they don't show up if the player replays the game
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

    #region Food Fall Frenzy Functions

    // This functions is called when a player collides with a food
    // Triggering the associated event
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

    // Checks to see if any player has won
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
        EventManager.instance.UpdateUI(2);
    }

    void CallFadeOut(int sceneIndex) {
        StartCoroutine(SceneFadeOut(sceneIndex));

        // Disables to ability to trigger events when the fade-out has begun
        // Such as the player clicking on a game too soon, before the fade-in has finished (doing this breaks the music switch)
        eventSystem.SetActive(false);
    }

    void CallFadeIn() {
        StartCoroutine(SceneFadeIn());
    }

    // Increases the alpha channel on a black image
    IEnumerator SceneFadeOut(int sceneIndex) {
        float screenAlpha = fadeScreen.GetComponent<Image>().color.a;

        // Stores the sceneIndex into a global variable
        // So the script doesn't have play hot potato with the sceneIndex value, passing it between too many functions
        currentScene = sceneIndex;

        while (screenAlpha < 1) {
            screenAlpha += waitTime;
            fadeScreen.GetComponent<Image>().color = new Color(0, 0, 0, screenAlpha);

            yield return new WaitForSeconds(waitTime);
        }

        // After the scene has faded out, trigger the event to fade the new scene in
        EventManager.instance.ScreenFade();
    }

    IEnumerator SceneFadeIn() {

        // Loads the new scene before it begins to fade-in
        LoadSceneUI();

        float screenAlpha = fadeScreen.GetComponent<Image>().color.a;

        while (screenAlpha > 0) {
            screenAlpha -= waitTime;
            fadeScreen.GetComponent<Image>().color = new Color(0, 0, 0, screenAlpha);

            yield return new WaitForSeconds(waitTime);
        }

        // Enables the ability to trigger events after the fade-in has completed
        eventSystem.SetActive(true);
    }
}
