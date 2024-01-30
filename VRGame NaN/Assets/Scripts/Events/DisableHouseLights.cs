using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AuditoryHallucinationTrigger class is responsible for triggering auditory hallucinations
public class DisableHouseLights : MonoBehaviour
{
    public string playerTag = "Player"; // The tag identifying the player camera
    public GameObject audioSourceObject; // The GameObject containing the AudioSource component to be triggered  
    public GameObject houseLights;

    // OnTriggerEnter is called when the player triggers the box collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag)) // Check if the collider belongs to the player
        {
            if (audioSourceObject != null) // Check if the audioSourceObject is assigned (not null)
            {
                AudioSource audioSource = audioSourceObject.GetComponent<AudioSource>(); // Get the AudioSource component from the audioSourceObject

                if (audioSource != null && !audioSource.isPlaying) // Check if the AudioSource component is assigned and not currently playing
                {
                    audioSource.Play(); // Play the audio via the AudioSource component
                    houseLights.SetActive(false);
                }
            }
        }
    }
}
