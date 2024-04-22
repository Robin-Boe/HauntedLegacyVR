using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhoulDeactive : MonoBehaviour
{
    // DIfferent timers (floats) and bool to check different conditions
    private float chaseTimer = 45.0f;
    private float eyeClosingEffectTimer = 5.0f;
    private bool scene_is_loading;

    // Gets the gameobjects of both controllers, locomotion and eye closing effect
    public GameObject leftController;
    public GameObject rightController;
    public GameObject locomotion;
    public GameObject eyeClosingEffect;

    // Gets the parent of all collectible objects
    public GameObject allObjects;

    // IF player touches the NPC's box collider
    void OnTriggerEnter (Collider other)
    {
        // If the object that touches the NPC is XR Origin, then the bool is true
        if (other.gameObject.name == "XR Origin (XR Rig)"){
            scene_is_loading = true;
        }
    }

    void Update()
    {
        // Timer of 45 seconds, which each frame reduces by 1
        chaseTimer -= Time.deltaTime;
        
        // If the player has touched the NPC
        if (scene_is_loading == true){
            // Timer to when the next scene should load
            eyeClosingEffectTimer -= Time.deltaTime;
            
            // Sets controllers, locomation to inactive and eye effect to active
            leftController.SetActive(false);
            rightController.SetActive(false);
            locomotion.SetActive(false);
            eyeClosingEffect.SetActive(true);
            
            // If timer is 0, load next screen
            if (eyeClosingEffectTimer <= 0.0f){
                SceneManager.LoadScene(3);
            }
        }
        // If the player has not been touched within 45 seconds, set NPC to inactive
        if (chaseTimer <= 0.0f){
            gameObject.SetActive(false);
            allObjects.SetActive(true);
        }
        // Disables narrative objects, to avoid the player collecting multiple during a chase
        else if (chaseTimer >= 0.1f){
            allObjects.SetActive(false);
        }
    }
}
