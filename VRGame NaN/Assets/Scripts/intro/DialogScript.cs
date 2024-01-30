using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogScript : MonoBehaviour
{
    public GameObject introText;
    public TMP_Text dialogText;
    private float timer = 79.0f;

    // Update is called once per frame
    void Update()
    {
        // Reduce the timer with 1 second each frame
        timer -= Time.deltaTime;
        
        // Text changes based on the timer, to be synced to the audio
        if (timer <= 0.0f){
            introText.SetActive(false);
        }
        else if (timer <= 1.0f){
            dialogText.text = @"<b>CHIEF:</b> Good luck!";
        }
        else if (timer <= 8.0f){
            dialogText.text = @"<b>CHIEF:</b> If the presence of dangerous 
            paranormal activity is nearby, your vision 
            will fade in and out with blackness 
            for 2 seconds.";
        }
        else if (timer <= 11.5f){
            dialogText.text = @"<b>CHIEF:</b> We have detected paranormal 
            activities within the vicinity.";
        }
        else if (timer <= 16.0f){
            dialogText.text = @"<b>CHIEF:</b> Once you have collected the paintings, 
            leave the vicinity as soon as possible.";
        }
        else if (timer <= 20.0f){
            dialogText.text = @"<b>CHIEF:</b> In this notebook you can keep track 
            of objectives and collectibles collected.";
        }
        else if (timer <= 25.0f){
            dialogText.text = @"<b>CHIEF:</b> To open your digital notebook, 
            press the button highlighted on 
              your glasses.";
        }
        else if (timer <= 28.5f){
            dialogText.text = @"<b>CHIEF:</b> and 2 more paintings of an 
            unnamed worker and couple.";
        }
        else if (timer <= 32.5f){
            dialogText.text = @"<b>CHIEF:</b> 2 paintings of the mansion's previous 
            owners, Mr. and Mrs. Grape,";
        }
        else if (timer <= 39.5f){
            dialogText.text = @"<b>CHIEF:</b> Your mission is to enter the 
            mansion, search and collect 4 paintings, 
            which are of significant value for 
            the Grape family.";
        }
        else if (timer <= 44.5f){
            dialogText.text = @"<b>CHIEF:</b> but will be repeated, *ughh* 
            so you don’t sabotage the investigation.";
        }
        else if (timer <= 49.0f){
            dialogText.text = @"<b>CHIEF:</b> It also allows us to contact you with 
            information you should already be familiar 
              with,";
        }
        else if (timer <= 51.0f){
            dialogText.text = @"<b>CHIEF:</b> in case you forgot.";
        }
        else if (timer <= 57.0f){
            dialogText.text = @"<b>CHIEF:</b> Among these are notifications 
            currently on screen highlighting 
            how you can walk and interact with objects,";
        }
        else if (timer <= 64.0f){
            dialogText.text = @"<b>CHIEF:</b> A pair of augmented reality glasses, which 
            will provide you with useful information 
              throughout your investigation.";
        }
        else if (timer <= 66.5f){
            dialogText.text = @"<b>CHIEF:</b> You've been equipped with the company's 
              newest invention;";
        }
        else if (timer <= 71.5f){
            dialogText.text = @"<b>CHIEF:</b> Hope your relaxing journey through 
            the forest landscape has made you ready for 
              the investigation.";
        }
        else if (timer <= 73.5f){
            introText.SetActive(true);
        }
        
    }
}
