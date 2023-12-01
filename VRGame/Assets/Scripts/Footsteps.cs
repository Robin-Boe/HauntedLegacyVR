using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private CharacterController cc;
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

    [SerializeField]
    private float cooldown = 0.5f;

    private float lastFootstepTime;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cc.isGrounded && cc.velocity.magnitude > minVelocityForFootsteps && !audioSource.isPlaying)
        {
            if (Time.time - lastFootstepTime > cooldown)
            {
                audioSource.volume = Random.Range(minVolume, maxVolume);
                audioSource.pitch = Random.Range(minPitch, maxPitch);
                audioSource.Play();
                lastFootstepTime = Time.time;
            }
        }
    }
}
