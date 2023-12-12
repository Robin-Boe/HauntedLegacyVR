using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        timerDis -= Time.deltaTime;
        basementDoor.SetActive(true);
        basementDoorNoAni.SetActive(false);

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
    }
}
