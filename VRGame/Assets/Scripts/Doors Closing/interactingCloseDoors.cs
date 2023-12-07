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
    

    // Function that is ran when interacting with the closed door
    public void CheckNarration(){
        if (timer <= -0.0f){
            player.PlayOneShot(playerTalking);
            subtitle.SetActive(true);
            timer = 5.0f;
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
