using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    // Subtitle
    public GameObject workerText;
    public TMP_Text dialogText;

    // Update is called once per frame
    void Update()
    {
        timerDis -= Time.deltaTime;

        // Sound and cutscene effect
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

        // Subtitles
        if (timerDis <= 0.0f){
            workerText.SetActive(false);
        }
        else if (timerDis <= 2.5f){ 
            dialogText.text = @"<b>WORKER:</b> JESUS CHRIST, NO PLEASE, NOOOOOOOOOOO";
        }
        else if (timerDis <= 4.0f){ 
            dialogText.text = @"<b>WORKER:</b> What is that sound?";
        }
        else if (timerDis <= 6.5f){ 
            dialogText.text = @"<b>WORKER:</b> I'm going to die... I'm going to die... I'm going to...";
        }
        else if (timerDis <= 8.8f){ 
            dialogText.text = @"<b>WORKER:</b> WAS THAT JUST A SCREAM?!";
        }
        else if (timerDis <= 9.3f){ 
            dialogText.text = @"*DISTANT SCREAMING*";
        }
        else if (timerDis <= 11.5f){ 
            dialogText.text = @"<b>WORKER:</b> Alright, and...";
        }
        else if (timerDis <= 13.0f){ 
            dialogText.text = @"<b>WORKER:</b> Yes, yes I should.";
        }
        else if (timerDis <= 16.0f){ 
            dialogText.text = @"<b>WORKER:</b> I should try to run to the gate.";
        }
        else if (timerDis <= 17.0f){ 
            dialogText.text = @"<b>WORKER:</b> Maybe they did...";
        }
        else if (timerDis <= 19.7f){ 
            dialogText.text = @"<b>WORKER:</b> Hope they didn't spot me going up in the attic...";
        }
        else if (timerDis <= 22.5f){ 
            dialogText.text = @"<b>WORKER:</b>  But... then just out of nowhere they...";
        }
        else if (timerDis <= 24.5f){ 
            dialogText.text = @"<b>WORKER:</b>  They are usually such nice people...";
        }
        else if (timerDis <= 27.0f){ 
            dialogText.text = @"<b>WORKER:</b>  What just happened with Mr. and Mrs. Grape?";
        }
        else if (timerDis <= 29.5f){
            workerText.SetActive(true);
        }

    }
}
