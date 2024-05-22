using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    // Player
    public Transform head;
    private float spawnDistance = 2.25f;

    // Movement
    public GameObject move;
    public GameObject turn;

    // Note
    public GameObject noteGameworld;

    // Audio
    public AudioSource paperLine;
    public AudioClip paperClip;
    public AudioSource voiceLine; 
    public AudioClip voiceClip;

    // Interface Pop-up
    public GameObject noteParent;
    public GameObject notePopup;

    // Pause Menu
    public GameObject pauseMenu;

    public void PopUp(){
        // Set note to active
        noteParent.SetActive(true);
        notePopup.transform.position = head.position + new Vector3(head.forward.x,0,head.forward.z).normalized / spawnDistance;
        
        // Play paper sound
        paperLine.PlayOneShot(paperClip);

        // Set movement off
        move.SetActive(false);
        turn.SetActive(false);

        // Play player dialog
        voiceLine.PlayOneShot(voiceClip);

        // Disable gameworld note
        noteGameworld.SetActive(false);

        // Temporarily diable activation of pause menu to avoid conflict between note and pause menu
        pauseMenu.SetActive(false);
    }

    public void PopClose(){
        // Set note to false
        noteParent.SetActive(false);
        
        // Play paper sound
        paperLine.PlayOneShot(paperClip);

        // Set movement on
        move.SetActive(true);
        turn.SetActive(true);

        // Stop player dialog
        voiceLine.Stop();

        // Enable gameworld note
        noteGameworld.SetActive(true);

        // Activate activation of pause menu
        pauseMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Move note to the player's head position
        notePopup.transform.LookAt(new Vector3 (head.position.x, notePopup.transform.position.y, head.position.z));
        notePopup.transform.forward *= -1;
    }
}
