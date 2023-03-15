using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour {

    public static EventManager instance;

    // Start is called before the first frame update
    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    public event Action<int> OnUpdateUI;

    // Events for BananaPistolsAtDawn
    public event Action DisplayAlert_BPAD;
    public event Action<string> DisplayWinner_BPAD;
    public event Action<string, string, bool> DisplayPlayerInput_BPAD;

    // Events for FoodFallFrenzy
    public event Action<bool, GameObject> OnCollectFood_FFF;
    public event Action DisplayWinner_FFF;

    public void UpdateUI(int sceneIndex) {
        OnUpdateUI?.Invoke(sceneIndex);
    }

    #region Event Functions for BananaPistolsAtDawn
    public void BPAD_DisplayAlert() {
        DisplayAlert_BPAD?.Invoke();
    }

    public void BPAD_DisplayWinner(string winnerName) {
        DisplayWinner_BPAD?.Invoke(winnerName);
    }

    public void BPAD_DisplayPlayerInput(string playerOneInput, string playerTwoInput, bool playerOne) {
        DisplayPlayerInput_BPAD?.Invoke(playerOneInput, playerTwoInput, playerOne);
    }
    #endregion

    #region Event Functions for FoodFallFrenzy
    public void FFF_CollectFood(bool playerOne, GameObject food) {
        OnCollectFood_FFF?.Invoke(playerOne, food);
    }

    public void FFF_DisplayWinner() {
        DisplayWinner_FFF?.Invoke();
    }
    #endregion
}
