using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockageManson : MonoBehaviour
{
    // Wall and Panel
    public GameObject panel;
    public GameObject wall;

    // Flashlight
    public GameObject flashlightNotifiction;

    // Player
    public GameObject player;

    // Timer
    private float timer = 60.5f;

    // When the player enters the threshold
    void OnTriggerEnter (Collider other)
    {
        // If the narration is still active and the player is entered
        if ((timer >= 0.1f) && (other.gameObject.name == "XR Origin (XR Rig)")){
            panel.SetActive(true);
            wall.SetActive(true);
        }
    }

    // If the player leaves the threshold disable the walls
    void OnTriggerExit (Collider other)
    {
        panel.SetActive(false);
        wall.SetActive(false);
    }

    void Update()
    {
        // Reduce the timer with 1 each second, stop it once it's at -5
        if (timer >= -5.0f){
            timer -= Time.deltaTime;
        }

        // If the timer is 0 (which is when the narration is over), disable the wall
        if (timer <= 0.0f){
            panel.SetActive(false);
            wall.SetActive(false);
            flashlightNotifiction.SetActive(true);
        }

        // Move the panel according to the player's x position
        panel.transform.position = new Vector3(player.transform.position.x, panel.transform.position.y, panel.transform.position.z);
    }
}
