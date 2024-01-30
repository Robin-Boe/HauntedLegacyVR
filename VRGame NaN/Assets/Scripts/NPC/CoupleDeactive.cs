using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoupleDeactive : MonoBehaviour
{
    private float timerDis = 29.5f;
    // Fade out of white sound effect
    public AudioSource fade;
    public AudioClip fadeSound;

    // Boy (Couple) Gameobject and sound
    public GameObject couple_boy;
    public AudioSource screamingFalling;
    public AudioClip scream;

    // Girl (Couple) Screaming
    public AudioSource girlScreaming;
    public AudioClip screamGirl;
    
    // Basement door closing and opening
    public GameObject basementDoor;
    public GameObject basementDoorNoAni;
    public AudioSource doorOpening;
    public AudioClip opening;

    // Variabels To Avoid Repeating Events
    private int timerCheck = 1;
    private int timerCheckv2 = 1;
    private int timerCheckv3 = 1;

    // Subtitle
    public GameObject coupleText;
    public TMP_Text dialogText;

    // Update is called once per frame
    void Update()
    {
        timerDis -= Time.deltaTime;
        basementDoor.SetActive(true);
        basementDoorNoAni.SetActive(false);

        // Sound and cutscene effect
        if (timerDis <= 0.0f){
            gameObject.SetActive(false);
            couple_boy.SetActive(false);
        }
        else if ((timerDis <= 2.0f) && (timerCheck == 1)){
            fade.PlayOneShot(fadeSound);
            timerCheck = 0;
        }
        else if ((timerDis <= 9.0f) && (timerCheckv2 == 1)){
            couple_boy.SetActive(true);
            doorOpening.PlayOneShot(opening);
            screamingFalling.PlayOneShot(scream);
            timerCheckv2 = 0;
        }   
        else if ((timerDis <= 7.5f) && (timerCheckv3 == 1)){
            girlScreaming.PlayOneShot(screamGirl);
            timerCheckv3 = 0;
        }

        // Subtitles
        if (timerDis <= 1.0f){
            coupleText.SetActive(false);
        }
        else if (timerDis <= 3.0f){ 
            dialogText.text = @"<b>GIRL:</b> Josh? JOSH!!!";
        }
        else if (timerDis <= 4.0f){ 
            dialogText.text = @"<b>GIRL:</b> OH MY GOD!";
        }
        else if (timerDis <= 8.2f){ 
            dialogText.text = @"*SCREAMING*";
        }
        else if (timerDis <= 9.0f){ 
            dialogText.text = @"*DOOR OPENS*";
        }
        else if (timerDis <= 11.5f){ 
            dialogText.text = @"";
        }
        else if (timerDis <= 15.0f){ 
            dialogText.text = @"<b>GIRL:</b> It does not look abandoned, as it was rumored to be...";
        }
        else if (timerDis <= 19.0f){ 
            dialogText.text = @"<b>GIRL:</b> The lights are still working and the maze outside looks trimmed.";
        }
        else if (timerDis <= 23.5f){ 
            dialogText.text = @"<b>GIRL:</b> Frankly, we should have never entered this mansion in the first place...";
        }
        else if (timerDis <= 26.5f){ 
            dialogText.text = @"<b>GIRL:</b>  I knew we should have never split up...";
        }
        else if (timerDis <= 29.5f){
            coupleText.SetActive(true);
        }
    }
}
