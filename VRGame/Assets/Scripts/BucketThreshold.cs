using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketThreshold : MonoBehaviour
{
    /* All code here is identical to the other script (TutorialScript). The entire purpose of this script
    is to make sure the bucket sequence is played so the player can observe it no matter how
    far they have progressed. This is due to the notifications being played in sequence, so the player
    could be further forward before this animation is played */

    // Bucket
    public GameObject bucket;
    public GameObject bucket2;
    public AudioSource bucketAudio;
    public AudioClip windBucket;

    void Bucket(){
        bucket.SetActive(false);
        bucket2.SetActive(true);
    }

    void OnTriggerEnter (Collider other)
    {
        if (bucket.activeSelf){
                bucketAudio.PlayOneShot(windBucket);
                bucket.GetComponent<Animator>().enabled = true;
                Invoke("Bucket", 5);
        }
    }
}