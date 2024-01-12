using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorLightSwitch : MonoBehaviour
{
    // Timers & Checks
    private int eventCheck = 1;
    private float timer = 4.0f;

    // Subtitle
    public GameObject subtitle;

    // NPC
    public GameObject monster;

    // Lights
    public GameObject lightOne;
    public GameObject lightTwo;

    void subtitleWerewolf(){
        subtitle.SetActive(true);
    }

    public void LightSwitch(){
        // If event has been ran
        if (eventCheck == 0){
            // If lights are on, turn them off
            if ((lightOne.activeSelf) && (lightTwo.activeSelf)){
                lightOne.SetActive(false);
                lightTwo.SetActive(false);
            }
            // If lights are off, turn them on
            else if ((!lightOne.activeSelf) && (!lightTwo.activeSelf)){
                lightOne.SetActive(true);
                lightTwo.SetActive(true);
            }
        }

        // Activate event
        if (eventCheck == 1){
            lightOne.SetActive(false);
            lightTwo.SetActive(false);
            monster.SetActive(true);
            Invoke("subtitleWerewolf", 0.8f);
            eventCheck = 2;
        }
    }

    void Update()
    {
        // Event duration, end after 4 seconds
        if (eventCheck == 2){
            timer -= Time.deltaTime;
            if (timer <= 0.0f){
                monster.SetActive(false);
                lightOne.SetActive(true);
                lightTwo.SetActive(true);
                eventCheck = 0;
            }
        }
    }
}
