using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorClosingSequence : MonoBehaviour
{
    // Check
    private int doorCheck = 0;
    public GameObject checkIfPlayer;

    // Right Door
    public Animator rightDoorAnim;

    // Left Door
    public Animator leftDoorAnim;

    // Audio
    public AudioSource closeDoor;
    public AudioClip windClose;

    // Audio Ghost
    public GameObject ghostAudio;
    public GameObject ghostSubtitle;

    // Car
    public GameObject car;

    // Objectives
    public GameObject enterMansionNotComplete;
    public GameObject enterMansionComplete;
    public GameObject find4Paintings;
    public GameObject enterTheMansionCompleteIcon;
    public GameObject collectfourPaintingsObjective;

    // Function that sets the notification to active
    void fourPaintings(){
        find4Paintings.SetActive(true);
    }

    void ghostTalking(){
        ghostSubtitle.SetActive(true);
        ghostAudio.SetActive(true);
    }

    void doorClose()
    {
        // Audio
        closeDoor.PlayOneShot(windClose);

        // Leftdoor
        leftDoorAnim.Play("doorClosingLeft");

        // Rightdoor
        rightDoorAnim.Play("doorClosingRight");

        // Car disable
        car.SetActive(false);

        // Objectives
        enterMansionNotComplete.SetActive(false);
        enterMansionComplete.SetActive(true);
        enterTheMansionCompleteIcon.SetActive(true);
        collectfourPaintingsObjective.SetActive(true);

        // To avoid both the completed notficiation and new notification to overlap, a 5 second pause is added to activate the new objective
        Invoke("fourPaintings", 5);
        Invoke("ghostTalking", 2);
    }

    // Start is called before the first frame update
    void OnTriggerEnter (Collider other)
    {
        if ((other.gameObject.name == "XR Origin (XR Rig)") && (doorCheck == 0)){
            doorClose();
            doorCheck = 1;
        }

        // If player enters, set check to true
        if (other.gameObject.name == "XR Origin (XR Rig)"){
            checkIfPlayer.SetActive(true);
        }
        
    }

    void OnTriggerExit (Collider other)
    {
        // If player exits, set check to false, to deactivate door selection from outside
        if (other.gameObject.name == "XR Origin (XR Rig)"){
            checkIfPlayer.SetActive(false);
        }        
    }
}
