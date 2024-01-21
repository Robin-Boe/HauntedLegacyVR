using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactingCloseDoors : MonoBehaviour
{
    // Timer so player doesn't "spam click it" and check to avoid it being triggered multiple times
    private float timer = 5.0f;
    private int paintingsCheck = 1;

    // Audio and subtitles
    public AudioSource player;
    public AudioClip playerTalking;
    public GameObject subtitle;

    // Objectives
    public GameObject newExitNotification;
    public GameObject findANewExitObjective;
    
    public GameObject doorObjectiveList;
    public GameObject keyObjectiveList;
    public GameObject keyObjectiveComplete;
    

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
            // To check if the basement door or key has been interacted with, Invoked with 4 seconds to avoid overlap with narration if the player interacts with immediatly
            if (((paintingsCheck == 1) && (!keyObjectiveList.activeSelf)) && ((!doorObjectiveList.activeSelf) || (!keyObjectiveComplete.activeSelf))){
                findANewExitObjective.SetActive(true);
                Invoke("newExit", 4);
            }
            // IF key interacted with (but not basement door) and player interacts with front door
            else if ((paintingsCheck == 1) && (keyObjectiveList.activeSelf)){
                findANewExitObjective.SetActive(true);
                newExit();
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
