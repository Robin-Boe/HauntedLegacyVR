using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.InputSystem;

public class Drafts_3 : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public InputAction playVideoAction;
    public InputAction pauseVideoAction;

    void Awake()
    {
        playVideoAction.performed += PlayVideo;
        pauseVideoAction.performed += PauseVideo;

    }
    void OnEnable()
    {
        if (playVideoAction != null)
            playVideoAction.Enable();
        if (pauseVideoAction != null)
            pauseVideoAction.Enable(); 
    }

    void OnDisable()
    {
        if (playVideoAction != null)
            playVideoAction.Disable();
        if (pauseVideoAction != null)
            pauseVideoAction.Disable();
    }
    public void PlayVideo(InputAction.CallbackContext context)
    {
        videoPlayer.Play();
    }
    public void PauseVideo(InputAction.CallbackContext context)
    {
        videoPlayer.Pause();
    }

    
}
