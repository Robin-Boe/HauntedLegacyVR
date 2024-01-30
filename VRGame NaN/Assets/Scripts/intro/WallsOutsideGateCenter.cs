using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsOutsideGateCenter : MonoBehaviour
{
    // Wall and Panel
    public GameObject panel;
    public GameObject wall;

    // Player
    public GameObject player;

    // Timer
    private float initalTimer = 10.0f;
    
    // If the player enters the area and the intro (car scene) is over, then whenever player is within the threshold, activate the panel and wall
    void OnTriggerEnter (Collider other)
    {
        if ((initalTimer <= 0.0f) && (other.gameObject.name == "XR Origin (XR Rig)")){
            panel.SetActive(true);
            wall.SetActive(true);
        }
    }
    
    // Set the panel and wall to inactive when the player exits the threshold
    void OnTriggerExit (Collider other)
    {
        panel.SetActive(false);
        wall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If timer is above minus 2, then reduce the timer
        if (initalTimer >= -2.0f){
            initalTimer -= Time.deltaTime;
        }

        // Move the panel according to the player's x position
        panel.transform.position = new Vector3(player.transform.position.x, panel.transform.position.y, panel.transform.position.z);
    }
}
