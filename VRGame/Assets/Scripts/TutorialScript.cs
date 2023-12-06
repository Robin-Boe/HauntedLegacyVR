using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialScript : MonoBehaviour
{
    // Keeps track of which notification should be played
    private int countControl = 0; 
    private int countControlGrab = 1; 
    private int countControlMenu = 1; 
    private int countControlUI = 1; 
    
    // Grab Notification
    public InputActionReference grabButton = null;
    public GameObject grabNotification;
    public GameObject grabNotificationAni;
    public GameObject bucket;
    public GameObject bucket2;
    public AudioSource bucketAudio;
    public AudioClip windBucket;
    private int audioCheck = 0;
    private float grabTimer = 18.0f;
    private float grabTimer2 = 23.0f;

    // Turn Notification
    public InputActionReference menuButton = null;
    public GameObject menuNotification;
    public GameObject narration;
    public GameObject narrationIcon;
    private float narrationTimer = 52.0f;

    // UI Notification
    public InputActionReference uiButton = null;
    public GameObject uiNotification;
    public GameObject uiNotificationAni;

    // Grab Notification (Called when button pressed)
    void Grab(InputAction.CallbackContext context){
        grabNotification.SetActive(false);
        grabNotificationAni.SetActive(true);
        countControl = 1;
        countControlGrab = 0;
    }

    // Part of Grab Sequence
    void Bucket(){
        bucket.SetActive(false);
        bucket2.SetActive(true);
    }

    // Menu Notification (Called when button pressed)
    void Menu(InputAction.CallbackContext context){
        menuNotification.SetActive(false);
        countControl = 2;
        countControlMenu = 0;
    }

    // UI Notification (Called when button pressed)
    void UI(InputAction.CallbackContext context){
        uiNotification.SetActive(false);
        uiNotificationAni.SetActive(true);
        countControl = 3;
        countControlUI = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((countControl == 0) && (countControlGrab == 1)){
            grabTimer -= Time.deltaTime;
            grabTimer2 -= Time.deltaTime;
            if ((grabTimer <= 0.0f) && (bucket.activeSelf)){
                if (audioCheck == 0) {
                    bucketAudio.PlayOneShot(windBucket);
                    audioCheck = 1;
                }
                bucket.GetComponent<Animator>().enabled = true;
                Invoke("Bucket", 5);
            }
            if (grabTimer2 <= 0.0f){
                grabNotification.SetActive(true);
                grabButton.action.started += Grab;
            }
        }  
        else if ((countControl == 1) && (countControlMenu == 1)){
            menuNotification.SetActive(true);
            narration.SetActive(true);
            narrationIcon.SetActive(true);
            narrationTimer -= Time.deltaTime;
            if (narrationTimer <= 0){
                menuButton.action.started += Menu;
            }
        }
        else if ((countControl == 2) && (countControlUI == 1)){
            uiNotification.SetActive(true);
            uiButton.action.started += UI;
        }
    }
}
