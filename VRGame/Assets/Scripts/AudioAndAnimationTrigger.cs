using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAndAnimationTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator animator;

    void OnTriggerEnter(Collider other)
    {
        animator = GetComponent<Animator>();

        if (other.gameObject.name == "XR Origin (XR Rig)" && !audioSource.isPlaying)
        {
            audioSource.Play();
            animator.enabled = !animator.enabled;
        }
    }
}
