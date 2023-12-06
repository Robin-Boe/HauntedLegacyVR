using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorClosingSequence : MonoBehaviour
{
    // Check
    private int doorCheck = 0;

    // Right Door
    public Animator rightDoorAnim;
    public BoxCollider rightDoorCollider;

    // Left Door
    public Animator leftDoorAnim;
    public BoxCollider leftDoorCollider;

    // Audio
    public AudioSource closeDoor;
    public AudioClip windClose;

    void doorClose()
    {
        // Audio
        closeDoor.PlayOneShot(windClose);

        // Leftdoor
        leftDoorAnim.Play("doorClosingLeft");
        leftDoorCollider.enabled = true;

        // Rightdoor
        rightDoorAnim.Play("doorClosingRight");
        rightDoorCollider.enabled = true;
    }

    // Start is called before the first frame update
    void OnTriggerEnter (Collider other)
    {
        if (doorCheck == 0){
            doorClose();
            doorCheck = 1;
        }
    }

    // Update is called once per frame
    /*void OnTriggerStay (Collider other)
    {
        Debug.Log("Stay");
    }*/
    
    /*void OnTriggerExit (Collider other)
    {
        Debug.Log("Leave");
    }*/
}
