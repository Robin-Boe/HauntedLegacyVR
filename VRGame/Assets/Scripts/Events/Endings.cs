using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class Endings : MonoBehaviour
{
    // Paintings
    public GameObject Couple;
    public GameObject Woman;
    public GameObject Man;
    public GameObject Worker;

    // Grab Detection
    public InputActionReference grabButton = null;
    private int countGrab = 0;

    // Hints, Glows & Notifications
    public GameObject placePaiting;
    public GameObject burnPaiting;
    public GameObject dirtGlow;

    // Fire
    public GameObject fire;

    // Fade
    public GameObject fade;

    // Objective
    public GameObject leavePropertyCheckMark;
    public GameObject leavePropertyNotification;

    // Box Texts
    public Text leftText;
    public Text rightText;
    public Text middleText;

    // NPC
    public GameObject Emily;
    public GameObject Ghoul;
    public GameObject Yokai;

    // 0 Paintings Collected Objects
    private float ZeroPaintingsTimer = 10;
    public GameObject enteredMansion;
    public GameObject dialog0Paintings;
    public GameObject dialog0PaintingsText;
    public TMP_Text dialogText0Paintings;

    // 1 - 3 Paintings Collected
    public GameObject dialogOneOrMorePaintings;
    public GameObject dialogOneOrMorePaintingsSubtitle;

    // Load to Main Menu
    void LoadOtherScene()
    {
        SceneManager.LoadScene(0);
    }

    void LoadOtherSceneOffice()
    {
        SceneManager.LoadScene(4);
    }

    // Fade OUT
    void Fade()
    {
        fade.SetActive(true);
    }

    // Grab Notification (Called when button pressed)
    void Grab(InputAction.CallbackContext context){
        if ((placePaiting.activeSelf) && (countGrab == 0)){
            placePaiting.SetActive(false);
            countGrab = 1;
        }
        else if ((burnPaiting.activeSelf) && (countGrab == 1)){
            burnPaiting.SetActive(false);
            countGrab = 2;

            // Objectives
            leavePropertyCheckMark.SetActive(true);
            leavePropertyNotification.SetActive(true);
        }
    }

    // When the player enters the threshold
    void OnTriggerEnter (Collider other)
    {
        // If the player has not collected any paintings but goes to the gate
        if ((AllObjectsAreActive()) && (enteredMansion.activeSelf)){
            //Audio
            dialog0Paintings.SetActive(true);
            dialog0PaintingsText.SetActive(true);

            //Fade & Scene Loader
            Invoke("Fade", 3);
            Invoke("LoadOtherScene", 9);
        }
        else if ((!AllObjectsAreInactive()) && (!Couple.activeSelf || !Woman.activeSelf || !Man.activeSelf || !Worker.activeSelf)){
            dialogOneOrMorePaintings.SetActive(true);
            dialogOneOrMorePaintingsSubtitle.SetActive(true);
            
            Invoke("Fade", 3);
            Invoke("LoadOtherSceneOffice", 9);
        }
    }

    // When the player stays within the box collider
    void OnTriggerStay (Collider other)
    {
        // If the player has all the paintings and gotton to the gate
        if ((AllObjectsAreInactive()) && (other.gameObject.name == "XR Origin (XR Rig)")){
            // Change box text (if player tries to keep walking beyond the designated area
            leftText.text = @"Keep your focus on the mission!
    Burn the Paintings!";
            rightText.text = @"Keep your focus on the mission!
    Burn the Paintings!";
            middleText.text = @"Keep your focus on the mission!
    Burn the Paintings!";

            // Place paintings interaction
            if (countGrab == 0){
                dirtGlow.SetActive(true);
                placePaiting.SetActive(true);
                grabButton.action.started += Grab;
            }
            // Set them ablaze interaction
            else if (countGrab == 1){
                burnPaiting.SetActive(true);
                grabButton.action.started += Grab;
            }
        }
    }
    
    void Update()
    {
        // When paintings are set ablaze
        if (fire.activeSelf){
            Emily.SetActive(false);
            Ghoul.SetActive(false);
            Yokai.SetActive(false);
        }
        else if (dialog0Paintings.activeSelf){
            ZeroPaintingsTimer -= Time.deltaTime;

            if (ZeroPaintingsTimer <= 1.0f){
                dialog0PaintingsText.SetActive(false);
            }
            else if (ZeroPaintingsTimer <= 4.5f){
                dialogText0Paintings.text = @"<b>PLAYER:</b> Done...";
            }
            else if (ZeroPaintingsTimer <= 5.8f){
                dialogText0Paintings.text = @"<b>PLAYER:</b> I'm just...";
            }
            else if (ZeroPaintingsTimer <= 8.0f){
                dialogText0Paintings.text = @"<b>PLAYER:</b> I have had enough excitement for my lifetime.";
            }
        }
    }

    // All paintings are active = Not picked up
    bool AllObjectsAreActive()
    {
        return Couple.activeSelf && Woman.activeSelf && Man.activeSelf && Worker.activeSelf;
    }

    // All paintings are inactive = Picked Up
    bool AllObjectsAreInactive()
    {
        return !Couple.activeSelf && !Woman.activeSelf && !Man.activeSelf && !Worker.activeSelf;
    }
}
