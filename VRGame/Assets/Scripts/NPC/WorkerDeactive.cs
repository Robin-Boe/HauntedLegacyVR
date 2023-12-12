using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerDeactive : MonoBehaviour
{
    private float timerDis = 29.5f;
    // Fade out of white sound effect
    public AudioSource fade;
    public AudioClip fadeSound;

    // Girl (Couple) Screaming Downstairs
    public AudioSource girlScreaming;
    public AudioClip screamGirl;

    // Screaming downstairs
    public AudioSource screamingFalling;
    public AudioClip scream;
    
    // Basement door closing and opening
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

        if (timerDis <= 0.0f){
            gameObject.SetActive(false);
        }
        else if ((timerDis <= 2.0f) && (timerCheck == 1)){
            fade.PlayOneShot(fadeSound);
            timerCheck = 0;
        }
        else if ((timerDis <= 9.0f) && (timerCheckv2 == 1)){
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
