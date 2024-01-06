using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchRandomizer : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private float minVolume = 0.8f;

    [SerializeField]
    private float maxVolume = 1f;

    [SerializeField]
    private float minPitch = 0.8f;

    [SerializeField]
    private float maxPitch = 1.1f;

    [SerializeField]
    private float waitTime = 2f;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timer = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            if (timer <= 0f)
            {
                audioSource.volume = Random.Range(minVolume, maxVolume);
                audioSource.pitch = Random.Range(minPitch, maxPitch);
                timer = waitTime;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
}
