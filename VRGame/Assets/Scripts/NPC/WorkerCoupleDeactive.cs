using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerCoupleDeactive : MonoBehaviour
{
    private float timerDis = 29.5f;
    // Fade out of white sound effect
    public AudioSource fade;
    public AudioClip fadeSound;

    // Screaming downstairs
    public AudioSource screamingFalling;
    public AudioClip scream;
    
    private int timerCheck = 1;
    private int timerCheckv2 = 1;

    // Start is called before the first frame update

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
            screamingFalling.PlayOneShot(scream);
            timerCheckv2 = 0;
        }   
    }
}
