using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    // NPC
    public GameObject Emily;
    public GameObject Ghoul;
    public GameObject Yokai;

    // Grab Notification (Called when button pressed)
    void Grab(InputAction.CallbackContext context){
        if ((placePaiting.activeSelf) && (countGrab == 0)){
            placePaiting.SetActive(false);
            countGrab = 1;
        }
        else if ((burnPaiting.activeSelf) && (countGrab == 1)){
            burnPaiting.SetActive(false);
            countGrab = 2;
        }
    }

    // When the player stays within the box collider
    void OnTriggerStay (Collider other)
    {
        if ((AllObjectsAreInactive()) && (other.gameObject.name == "XR Origin (XR Rig)")){
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
