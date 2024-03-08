using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class NewIntroSequence : MonoBehaviour
{
    // Player
    public Transform head;

    // Key
    public GameObject key;

    // Menu and Flashlight Button Reference
    public InputActionReference menuButton = null;
    public InputActionReference flashlightButton = null;

    // Interfaces
    public GameObject pausemenu;
    public GameObject menuInterface;
    public GameObject triggerInterface;
    public GameObject flashlightInterface;

    // Gate Animations and Audio for Gate
    public BoxCollider gate;
    public Animator rightGateAnim;
    public Animator leftGateAnim;
    public AudioSource gateAudio;
    public AudioClip gateOpeningSound;
    public AudioClip lockedSound;

    // Audio Player and Clips
    public AudioSource audioPlayer;
    public AudioClip introAudio;
    public AudioClip keyCollectedAudio;
    public AudioClip menuOpenedAudio;
    public AudioClip introEndingAudio;

    // Subtitle
    public GameObject introText;
    public TMP_Text dialogText;

    // Fade and objective
    public GameObject fadeExample;
    public GameObject firstObjectivePopup;

    // Check to test progression
    private int checkIfKeyCollected = 0;
    private int checkIfMenuPressed = 0;
    private int checkIfGateOpened = 0;
    private int checkIfPauseMenuUnpressed = 0;
    private int flashlightPressed = 0;

    // Timers
    private float timer = 28.5f;

    // Activates the interface tutorial for menu
    void activateMenuInterface(){
        // If menu is not pressed, then activate
        if (checkIfMenuPressed == 0){
            menuInterface.SetActive(true);
        }
    }

    // Sequence Happening When Key is Collected
    public void KeyCollected(){
        // Stops the playing audio, in case the player triggers it earlier
        if (audioPlayer.isPlaying){
            audioPlayer.Stop();
        }
        // Play chief audio
        audioPlayer.PlayOneShot(keyCollectedAudio);
        
        // Update check progression
        checkIfKeyCollected = 1;

        // Change timer value for new subtitle sequence
        timer = 21.5f;

        // Activate interface menu here through Invoke, e.g. 5 seconds later (timed to the dialog)
        Invoke("activateMenuInterface", 15);
    }

    // Flashlight (Called when button pressed)
    void Flashlight(InputAction.CallbackContext context){
        // Only run the first time the button is pressed
        if ((checkIfGateOpened == 1) && (flashlightPressed == 0)){
            // Update check value
            flashlightPressed = 1;

            // Deactive interface tutorial for flashlight 
            flashlightInterface.SetActive(false);
        }
    }

    // Menu (Called when button pressed)
    void Menu(InputAction.CallbackContext context){
        if ((checkIfKeyCollected == 1) && (checkIfMenuPressed == 0)){
            // Stops the playing audio, in case the player triggers it earlier
            if (audioPlayer.isPlaying){
                audioPlayer.Stop();
            }

            // Play chief audio
            audioPlayer.PlayOneShot(menuOpenedAudio);

            // Check Updated
            checkIfMenuPressed = 1;

            // Change timer value for new subtitle sequence
            timer = 21.5f;

            // Deactive interface tutorial for menu
            menuInterface.SetActive(false);

            // Deactivate menu interface here
            triggerInterface.SetActive(true);
        }
    }

    // Sequence Happening When Gate is Opened
    public void GateOpening(){
        // If the key has been picked up
        if ((!key.activeSelf) && (checkIfMenuPressed == 1)){
            // Gate Effects
            gateAudio.PlayOneShot(gateOpeningSound);
            rightGateAnim.Play("rightGate");
            leftGateAnim.Play("leftGate");

            // Check updated
            checkIfGateOpened = 1;

            // Disable box collider for gate
            gate.enabled = false;

            // Add flashlight interface here
            flashlightInterface.SetActive(true);
        }
        else{
            gateAudio.PlayOneShot(lockedSound);
        }
    }

    // Update is called once per frame
    void Update()
    {
        menuButton.action.started += Menu;
        flashlightButton.action.started += Flashlight;

        // Check if key has been collected and menu interacted with
        if (((!key.activeSelf) && (checkIfMenuPressed == 1)) && (checkIfGateOpened == 0)){
            gate.enabled = true;
        }
        // If only key, then deactivate interaction with gate
        else if (!key.activeSelf){
            gate.enabled = false;
        }

        // Check if pause menu has been pressed and deactived once, and play audio
        if (((checkIfMenuPressed == 1) && (!pausemenu.activeSelf)) && (checkIfPauseMenuUnpressed == 0)){
            // Stops the playing audio, in case the player triggers it earlier
            if (audioPlayer.isPlaying){
                audioPlayer.Stop();
            }

            // Chief Dialog
            audioPlayer.PlayOneShot(introEndingAudio);
            
            // Change check value
            checkIfPauseMenuUnpressed = 1;

            // Change timer value for new subtitle sequence
            timer = 36.5f;

             // New objective pop-up here
            firstObjectivePopup.SetActive(true);

            // Set fade black example to active
            fadeExample.SetActive(true);

            // Deactive UI tutorial
            triggerInterface.SetActive(false);

        }

        // Change the tutorial interfaces' position to same as head
        menuInterface.transform.LookAt(new Vector3 (head.position.x, menuInterface.transform.position.y, head.position.z));
        menuInterface.transform.forward *= -1;

        flashlightInterface.transform.LookAt(new Vector3 (head.position.x, flashlightInterface.transform.position.y, head.position.z));
        flashlightInterface.transform.forward *= -1;

        // Subtitles changes
        // If key has not been collected yet
        if (checkIfKeyCollected == 0){
            timer -= Time.deltaTime;
            if (timer <= 0.0f){
                dialogText.text = @"";
            }
            else if (timer <= 3.5f){
                dialogText.text = @"<b>CHIEF:</b> Apparently the last ones here 
              left in a real hurry.";
            }
            else if (timer <= 8.5f){
                dialogText.text = @"<b>CHIEF:</b> The gate should be closed, but there 
              should be a key that was dropped here 
              somewhere.";
            }
            else if (timer <= 11.0f){
                dialogText.text = @"<b>CHIEF:</b> Alright detective, let's get you ready.";
            }
            else if (timer <= 18.0f){
                dialogText.text = @"<b>CHIEF:</b> A pair of augmented reality glasses, which 
              will provide you with useful information 
              throughout your investigation.";
            }
            else if (timer <= 20.5f){
                dialogText.text = @"<b>CHIEF:</b> You've been equipped with the company's 
              newest invention;";
            }
            else if (timer <= 25.5f){
                dialogText.text = @"<b>CHIEF:</b> Hope your relaxing journey through 
               the forest landscape has made you ready 
                for the investigation.";
            }
            else if (timer <= 27.0f){
                introText.SetActive(true);
            }
        }
        // If menu has yet to be pressed
        else if (checkIfMenuPressed == 0){
            timer -= Time.deltaTime;
            if (timer <= 0.0f){
                dialogText.text = @"";
            }
            else if (timer <= 4.5f){
                dialogText.text = @"<b>CHIEF:</b> Press the button now highlighted 
                  in the glasses to open it.";
            }
            else if (timer <= 7.5f){
                dialogText.text = @"<b>CHIEF:</b> the glasses provide an interaction menu.";
            }
            else if (timer <= 9.5f){
                dialogText.text = @"<b>CHIEF:</b> When discussing tools by the glasses;";
            }
            else if (timer <= 14.5f){
                dialogText.text = @"<b>CHIEF:</b> It's a tool provided by the glasses, 
                to help you find objects that are 
                     significant.";
            }
            else if (timer <= 18.5f){
                dialogText.text = @"<b>CHIEF:</b> You might be wondering what that glow 
                  around the key was.";
            }
            else if (timer <= 21.5f){
                dialogText.text = @"<b>CHIEF:</b> By the sound of it, you found the key!";
            }
        }
        // If menu is not exited
        else if (checkIfPauseMenuUnpressed == 0){
            timer -= Time.deltaTime;
            if (timer <= 0.0f){
                dialogText.text = @"";
            }
            else if (timer <= 4.5f){
                dialogText.text = @"<b>CHIEF:</b> Don't take too long, as you 
                  are on the clock.";
            }
            else if (timer <= 7.5f){
                dialogText.text = @"<b>CHIEF:</b> or the X in the top of the glasses.";
            }
            else if (timer <= 11.5f){
                dialogText.text = @"<b>CHIEF:</b> Whenever you're ready, close the menu by 
                  pressing the button again,";
            }
            else if (timer <= 17.5f){
                dialogText.text = @"<b>CHIEF:</b> It also lets you change the 
                  settings of the glasses, or so I've been 
                 told by the IT department.";
            }
            else if (timer <= 21.5f){
                dialogText.text = @"<b>CHIEF:</b> The menu keeps you up to date with 
                the mission and objects you have collected.";
            }
        }
        // If menu is exited
        else if (checkIfPauseMenuUnpressed == 1){
            timer -= Time.deltaTime;
            if (timer <= 0.0f){
                introText.SetActive(false);
            }
            else if (timer <= 1.5f){
                dialogText.text = @"<b>CHIEF:</b> Good luck!";
            }
            else if (timer <= 5.0f){
                dialogText.text = @"<b>CHIEF:</b> your vision will fade in and out 
                with blackness for 2 seconds.";
            }
            else if (timer <= 9.0f){
                dialogText.text = @"<b>CHIEF:</b> If the presence of dangerous 
                  paranormal activity is nearby,";
            }
            else if (timer <= 13.0f){
                dialogText.text = @"<b>CHIEF:</b> We have detected paranormal 
                  activities within the vicinity.";
            }
            else if (timer <= 17.0f){
                dialogText.text = @"<b>CHIEF:</b> Once you have collected the paintings, 
                  leave the vicinity as soon as possible.";
            }
            else if (timer <= 20.0f){
                dialogText.text = @"<b>CHIEF:</b> and 2 more paintings of an 
                 unnamed worker and couple.";
            }
            else if (timer <= 23.0f){
                dialogText.text = @"<b>CHIEF:</b> 2 paintings of the mansion's previous 
                 owners, Mr. and Mrs. Grape,";
            }
            else if (timer <= 29.0f){
                dialogText.text = @"<b>CHIEF:</b> search and collect 4 paintings, 
                  which are of significant value for 
                    the Grape family.";
            }
            else if (timer <= 32.5f){
                dialogText.text = @"<b>CHIEF:</b> Your mission, once you're inside 
                  the property, is to enter the mansion";
            }
            else if (timer <= 36.5f){
                dialogText.text = @"<b>CHIEF:</b> Okay detective, use the key you found 
                  to open the gate.";
            }
        }
    }
}

