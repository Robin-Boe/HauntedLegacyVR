using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseOutside : MonoBehaviour
{
    // Check
    private int checkIfRan = 0;
    private int playerEntered = 0;
    private float timer = 10.5f;

    // Fade
    public GameObject whiteFade;
    public GameObject fadeSound;

    // NPC
    public GameObject monster;
    public GameObject solider;

    // If player enters the box collider
    void OnTriggerEnter (Collider other)
    {
        if ((checkIfRan == 0) && (other.gameObject.name == "XR Origin (XR Rig)")){
            checkIfRan = 1;
            playerEntered = 1;
            fadeSound.SetActive(true);
            whiteFade.SetActive(true);
            monster.SetActive(true);
            solider.SetActive(true);
        }
    }

    void Update()
    {
        // If timer is 0 or less set the monsters to inactive
        if (timer <= 0.0f){
            monster.SetActive(false);
            solider.SetActive(false);
        }
        // If player entered the trigger, run timer
        else if (playerEntered == 1){
            timer -= Time.deltaTime;
        }
    }
}
