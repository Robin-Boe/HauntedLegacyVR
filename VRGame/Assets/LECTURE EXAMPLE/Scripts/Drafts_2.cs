using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class Drafts_2 : MonoBehaviour
{
    public AudioSource anyAudioSource;

    public InputAction playAudioAction;  
    public InputAction pauseAudioAction;  
    public InputAction stopAudioAction;  

     void Awake()
    {
        playAudioAction.performed += TriggerAudio;
         pauseAudioAction.performed += PauseAudio;
        stopAudioAction.performed += StopAudio;

    }
   void OnEnable()  
    {
       if(playAudioAction != null)  
        playAudioAction.Enable();  
         if(pauseAudioAction != null)  
        pauseAudioAction.Enable(); 
         if(stopAudioAction != null)  
        stopAudioAction.Enable();  
    }

    void OnDisable() 
    {
       if(playAudioAction != null)  
        playAudioAction.Disable();  
         if(pauseAudioAction != null)  
        pauseAudioAction.Disable(); 
         if(stopAudioAction != null)  
        stopAudioAction.Disable();  
    }
    public void TriggerAudio(InputAction.CallbackContext context)
    {
        anyAudioSource.Play();
    }
    public void StopAudio(InputAction.CallbackContext context)
    {
        anyAudioSource.Stop();
    }
  
    public void PauseAudio(InputAction.CallbackContext context)
    {
        anyAudioSource.Pause();
    }
 
    
}