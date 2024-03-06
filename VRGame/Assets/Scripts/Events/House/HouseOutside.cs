using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;

public class HouseOutside : MonoBehaviour
{
    // Player
    public GameObject player;

    // Check
    private int checkIfRan = 0;
    private int playerEntered = 0;
    private int checkIfDeactivated = 0;
    private float timer = 12.5f;

    // Fade
    public GameObject whiteFade;
    public GameObject fadeSound;

    // NPC
    public GameObject monster;
    public GameObject solider;

    // Teleport Player
    void TeleportPlayer(){
        player.GetComponent<XROrigin>().MoveCameraToWorldLocation(new Vector3(15.123f, 1.5f, -48.717f));
    }

    // Activate Event
    void ActivateHouse(){
        monster.SetActive(true);
        solider.SetActive(true);
    }

    // If player enters the box collider
    void OnTriggerEnter (Collider other)
    {
        if ((checkIfRan == 0) && (other.gameObject.name == "XR Origin (XR Rig)")){
            checkIfRan = 1;
            playerEntered = 1;
            fadeSound.SetActive(true);
            whiteFade.SetActive(true);
            Invoke("TeleportPlayer", 1);
            Invoke("ActivateHouse", 2);
        }
    }

    void Update()
    {
        // If timer is 0 or less set the monsters to inactive
        if ((timer <= 0.0f) && (checkIfDeactivated == 0)){
            monster.SetActive(false);
            solider.SetActive(false);
            player.GetComponent<XROrigin>().MoveCameraToWorldLocation(new Vector3(11.595f, 1.7f, -43.73f));
            checkIfDeactivated = 1;
        }
        // If player entered the trigger, run timer
        else if (playerEntered == 1){
            timer -= Time.deltaTime;
        }
    }
}
