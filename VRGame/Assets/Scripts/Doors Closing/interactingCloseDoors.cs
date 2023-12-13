using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactingCloseDoors : MonoBehaviour
{
    // Timer so player doesen't "spam click it"
    private float timer = 5.0f;

    // Audio and subtitles
    public AudioSource player;
    public AudioClip playerTalking;
    public GameObject subtitle;

    // Objectives
    public GameObject newExitNotification;
    public GameObject findANewExitObjective;
    
    public GameObject doorObjectiveList;
    public GameObject keyObjectiveList;
    private int paintingsCheck = 1;

    // Function that sets the notification to active
    void newExit(){
        newExitNotification.SetActive(true);
        paintingsCheck = 0;
    }

    // Function that is ran when interacting with the closed door
    public void CheckNarration(){
        if (timer <= -0.0f){
            player.PlayOneShot(playerTalking);
            subtitle.SetActive(true);
            timer = 5.0f;
            // To avoid the subtitle and notification to overlap
            if ((paintingsCheck == 1) && ((!doorObjectiveList.activeSelf) && (!keyObjectiveList.activeSelf))){
                findANewExitObjective.SetActive(true);
                Invoke("newExit", 4);
            }
        }
    }

    // Each frame reduce timer, if timer is reduced to 0.2 or below avoid reducing it more to save capacity
    void Update()
    {
        if (timer <= -0.0f){
            subtitle.SetActive(false);
        }
        else {
            timer -= Time.deltaTime;
        }
    }
}
