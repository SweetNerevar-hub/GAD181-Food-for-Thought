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

        audioSource.clip = musicClips[sceneIndex - 1];
        audioSource.Play();
    }

    IEnumerator FadeAudioIn() {
        if (currentScene == 2) musicClips[1] = musicClips[0];

        while (audioSource.volume < 0.99f) {
            audioSource.volume += waitTime;

            yield return new WaitForSecondsRealtime(waitTime);
        }
    }
}
