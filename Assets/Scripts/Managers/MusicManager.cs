using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour {

    public static MusicManager instance;

    AudioSource audioSource;
    public AudioClip[] musicClips;

    float waitTime = 0.01f;

    int currentScene;

    private void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    // Start is called before the first frame update
    void Start() {
        audioSource = GetComponent<AudioSource>();

        // When the player triggers a scene change, call the FadeAudioOut function
        // Pretty much the same as the Screen Fade from the UI Manager, it follows the same steps
        EventManager.instance.OnUpdateUI += CallFadeAudioOut;
        EventManager.instance.OnScreenFade += CallFadeAudioIn;
    }

    void CallFadeAudioOut(int sceneIndex) {
        currentScene = sceneIndex;

        // This is so when the scene changes from Main Menu to Game Selection, the music carries over
        if (musicClips[sceneIndex - 1] == null) return;

        StartCoroutine(FadeAudioOut(sceneIndex));
    }

    void CallFadeAudioIn() {
        StartCoroutine(FadeAudioIn());
    }

    IEnumerator FadeAudioOut(int sceneIndex) {
        while (audioSource.volume > 0.01f) {
            audioSource.volume -= waitTime;

            yield return new WaitForSeconds(waitTime);
        }

        // Plays the music that corresponds to the current scene being loaded
        audioSource.clip = musicClips[sceneIndex - 1];
        audioSource.Play();
    }

    IEnumerator FadeAudioIn() {

        // If the Game Selection scene is loaded, insert the Main Menu music into the Game Selection music
        // This is really only used when transitioning from Main Menu to Game Selection
        // Where we don't want a music clip in the 1 slot so that the music carries over
        // But when we transition from a microgame to Game Selection, then start the Jazz Cafe music
        if (currentScene == 2) musicClips[1] = musicClips[0];

        while (audioSource.volume < 0.99f) {
            audioSource.volume += waitTime;

            // This makes it so the coroutine can still function, even when the Time.TimeScale is 0
            // Useful for the tutorials where we want music to play while gameplay is stopped
            yield return new WaitForSecondsRealtime(waitTime);
        }
    }
}
