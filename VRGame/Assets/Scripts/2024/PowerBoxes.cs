using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoxes : MonoBehaviour
{
    // Power Boxes Switches 1
    public GameObject switch1Interactable;
    public GameObject switch1NonInteractable;

    // Power Boxes Switches 2
    public GameObject switch2Interactable;
    public GameObject switch2NonInteractable;

    // House Lights
    public GameObject houseLights;

    // Flip Audio
    public GameObject flipAudio1;
    public GameObject flipAudio2;

    private float timer = 40.0f;
    private int check = 0;

    // Update is called once per frame
    public void PowerSwitch()
    {
        if (check == 0){
            flipAudio1.SetActive(false);
            flipAudio2.SetActive(false);
            check = 1;
        }
    }

    void Update(){
        if ((check == 1) && (timer >= 0.0f)){
            Debug.Log(timer);

            timer -= Time.deltaTime;

            houseLights.SetActive(true);

            // Disable the interactable switch
            switch1Interactable.SetActive(false);
            switch2Interactable.SetActive(false);

            // Enable the non interactable switch
            switch1NonInteractable.SetActive(true);
            switch2NonInteractable.SetActive(true);

            // Audio activate
            flipAudio1.SetActive(true);
            flipAudio2.SetActive(true);
        }
        else if ((check == 1) && (timer <= 0.0f)){
            // Disable audio to be able to replay it
            flipAudio1.SetActive(false);
            flipAudio2.SetActive(false);

            // Audio activate
            flipAudio1.SetActive(true);
            flipAudio2.SetActive(true);

            // Enable the interactable switch
            switch1Interactable.SetActive(true);
            switch2Interactable.SetActive(true);

            // Disable the non interactable switch
            switch1NonInteractable.SetActive(false);
            switch2NonInteractable.SetActive(false);

            // Disable house lights
            houseLights.SetActive(false);
            
            // Set check to 0 and timer to 40 so the lights can be activated again
            timer = 40.0f;
            check = 0;
        }
    }
}
