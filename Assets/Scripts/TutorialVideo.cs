using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class TutorialVideo : MonoBehaviour {

    public VideoClip[] videoClips;
    public RawImage videoRenderTexture;

    // Start is called before the first frame update
    void Start() {
        EventManager.instance.OnPlayTutorial += PlayTutorialVideo;
    }

    void PlayTutorialVideo(int sceneIndex) {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();

        // Make the TimeScale 0, so the tutorial can play before gameplay starts
        Time.timeScale = 0;

        if (sceneIndex == 3) {

            // Set video player clip to the Food Fall Frenzy tutorial
            videoPlayer.clip = videoClips[0];
            videoRenderTexture.transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(WhileTutorialPlaying(videoClips[0].length + 2));
            
        }

        else if(sceneIndex == 4) {

            // Set video player clip to the Banana Pistols at Dawn tutorial
            videoPlayer.clip = videoClips[1];
            StartCoroutine(WhileTutorialPlaying(videoClips[1].length + 2));
        }

        videoPlayer.Play();
        videoRenderTexture.enabled = true;
    }

    IEnumerator WhileTutorialPlaying(double clipLength) {
        while (clipLength > 0) {
            clipLength--;

            yield return new WaitForSecondsRealtime(1);
        }

        // Hide the video player when the tutorial ends
        videoRenderTexture.transform.GetChild(0).gameObject.SetActive(false);
        videoRenderTexture.enabled = false;

        // Start gameplay when tutorial ends
        Time.timeScale = 1;
    }

    private void OnDisable() {
        EventManager.instance.OnPlayTutorial -= PlayTutorialVideo;
    }
}
