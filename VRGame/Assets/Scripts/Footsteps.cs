using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private CharacterController characterController;
    private AudioSource audioSource;

    [SerializeField]
    private float minVelocityForFootsteps = 2f;

    [SerializeField]
    private float minVolume = 0.8f;

    [SerializeField]
    private float maxVolume = 1f;

    [SerializeField]
    private float minPitch = 0.8f;

    [SerializeField]
    private float maxPitch = 1.1f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded && characterController.velocity.magnitude > minVelocityForFootsteps && !audioSource.isPlaying)
        {
            audioSource.volume = Random.Range(minVolume, maxVolume);
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            audioSource.Play();
        }
    }
}
