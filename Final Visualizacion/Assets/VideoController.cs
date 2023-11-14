using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public UnityEvent On4SecPassed;
    public string sceneToLoad;

    private bool isPaused = false;
    private bool videoStarted;

    [SerializeField] CanvasGroup[] canvaces;

    private void Start()
    {
        StartCoroutine(Video());
    }
    IEnumerator Video()
    {
        yield return new WaitForSeconds(10f);
        canvaces[0].DOFade(0, 1);
        yield return new WaitForSeconds(1f);
        StartVideo();
    }
    void StartVideo()
    {
        // Retrieve the scene name from PlayerPrefs
        sceneToLoad = PlayerPrefs.GetString("SceneToLoad");
        // Assign the VideoPlayer component from the GameObject
        videoPlayer = GetComponent<VideoPlayer>();

        // Set up a method to be called when the video is done playing
        videoPlayer.loopPointReached += OnVideoEnd;

        // Start playing the video
        videoPlayer.Play();
        videoStarted = true;
        // Invoke a method to pause the video after 4 seconds
        Invoke("PauseVideo", 4f);
    }

    void Update()
    {
        // Check if the spacebar is pressed to resume the video
        if (Input.GetKeyDown(KeyCode.Space) && isPaused)
        {
            ResumeVideo();
        }
    }

    void PauseVideo()
    {
        // Pause the video
        videoPlayer.Pause();

        // Invoke the UnityEvent for 4 seconds passed
        On4SecPassed.Invoke();

        // Video is now paused
        isPaused = true;
    }

    // Public method to resume the video
    public void ResumeVideo()
    {
        // Resume the video
        videoPlayer.Play();

        // Video is no longer paused
        isPaused = false;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        Invoke("LoadScene", 5f);
        canvaces[1].DOFade(1, 1);
    }
    void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
