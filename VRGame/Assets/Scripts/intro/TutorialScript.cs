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
    private float grabTimer = 14.0f;
    private float grabTimer2 = 20.0f;

    // Menu Notification
    public InputActionReference menuButton = null;
    public GameObject menuNotification;
    public GameObject narration;
    public GameObject narrationIcon;
    private float narrationTimer = 52.0f;
    private float backupTimer = 52.0f;
    public GameObject check;
    private int checkNumber = 1;

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
        // --- GRAB ---
        if ((countControl == 0) && (countControlGrab == 1)){
            // Reduce the time with 1 second per frame
            grabTimer -= Time.deltaTime;
            grabTimer2 -= Time.deltaTime;
            // IF the timer is 0 or below and the bucket (which is ungrabbable) is currently active
            if ((grabTimer <= 0.0f) && (bucket.activeSelf)){
                if (audioCheck == 0) {
                    bucketAudio.PlayOneShot(windBucket);
                    audioCheck = 1;
                }
                bucket.GetComponent<Animator>().enabled = true;
                Invoke("Bucket", 5);
            }
            // IF the second timer is 0 or below set the notification to active and check for input
            if (grabTimer2 <= 0.0f){
                grabNotification.SetActive(true);
                grabButton.action.started += Grab;
            }
        }

        // --- MENU ---
        // In case the player starts the narration before they have gone through the grab notification
        if ((check.activeSelf) && (backupTimer >= -5.0f)){
            backupTimer -= Time.deltaTime;
        }

        // Menu Notification: If grab notification is complete OR the player entered the threshold  
        if (((countControl == 1) && (countControlMenu == 1)) || ((check.activeSelf) && (checkNumber == 1))){
            // If the player entered the threshold, change the checkNumber so it doesen't repeat each time the player enters
            if (check.activeSelf){
                 check.SetActive(false);
                 checkNumber = 0;
            }
            // Enables the narration and menu notification which is animated to start at certain times
            menuNotification.SetActive(true);
            narration.SetActive(true);
            narrationIcon.SetActive(true);

            narrationTimer -= Time.deltaTime;
            if ((narrationTimer <= 0) || (backupTimer <= 0)){
                menuButton.action.started += Menu;
            }
        }
        // --- UI Menu ---  
        // Shows up directly after the player clicks the menu button
        else if ((countControl == 2) && (countControlUI == 1)){
            uiNotification.SetActive(true);
            uiButton.action.started += UI;
        }
    }
}
