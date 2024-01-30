using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingDialoguePlayer : MonoBehaviour
{
    public GameObject couplePainting;
    public GameObject workerPainting;
    public GameObject womanPainting;
    public GameObject manPainting;

    private AudioSource audioSource;

    public AudioClip coupleWorkerAudio;
    public AudioClip womanAudio;
    public AudioClip manAudio;
    public AudioClip mrsGrapeFirstAudio;
    public AudioClip mrGrapeFirstAudio;
    public AudioClip mrsGrapeSecondAudio;
    public AudioClip mrGrapeSecondAudio;

    // Subtitles
    public GameObject mrGrapeFirstSubtitle;
    public GameObject mrGrapeSecondSubtitle;
    public GameObject mrsGrapeFirstSubtitle;
    public GameObject mrsGrapeSecondSubtitle;

    public GameObject self;

    private bool womanAudioPlayed1 = false;
    private bool womanAudioPlayed2 = false;
    private bool manAudioPlayed1 = false;
    private bool manAudioPlayed2 = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // int activePaintingsCount = CountActivePaintings();
        // Debug.Log("Active paintings count: " + activePaintingsCount);

        if (!womanPainting.activeSelf && manPainting.activeSelf && !womanAudioPlayed1)
        {
            Debug.Log("First woman painting is active.");
            PlayWomanAudio();
            Invoke("PlayMrsGrapeFirstAudio", 4f);
            womanAudioPlayed1 = true;
        }
        else if (!womanPainting.activeSelf && !manPainting.activeSelf && !womanAudioPlayed2 && manAudioPlayed1 && !manAudioPlayed2)
        {
            Debug.Log("Second woman painting is active.");
            PlayWomanAudio();
            Invoke("PlayMrsGrapeSecondAudio", 4f);
            womanAudioPlayed2 = true;
        }
        else if (!manPainting.activeSelf && womanPainting.activeSelf && !manAudioPlayed1)
        {
            Debug.Log("First man painting is active.");
            PlayManAudio();
            Invoke("PlayMrGrapeFirstAudio", 4f);
            manAudioPlayed1 = true;
        }
        else if (!manPainting.activeSelf && !womanPainting.activeSelf && !manAudioPlayed2 && womanAudioPlayed1 && !womanAudioPlayed2)
        {
            Debug.Log("Second man painting is active.");
            PlayManAudio();
            Invoke("PlayMrGrapeSecondAudio", 4f);
            manAudioPlayed2 = true;
        }
    }
/*
    // Method to count the active paintings
    int CountActivePaintings()
    {
        int count = 0;

        if (couplePainting != null && !couplePainting.activeSelf)
            count++;

        if (workerPainting != null && !workerPainting.activeSelf)
            count++;

        if (womanPainting != null && !womanPainting.activeSelf)
            count++;

        if (manPainting != null && !manPainting.activeSelf)
            count++;

        return count;
    }
*/
    void PlayCoupleWorkerAudio()
    {
        Debug.Log("play couple worker audio");
    }

    void PlayWomanAudio()
    {
        Debug.Log("play woman audio");
        audioSource.PlayOneShot(womanAudio);
    }

    void PlayManAudio()
    {
        Debug.Log("play man audio");
        audioSource.PlayOneShot(manAudio);
    }

    void PlayMrsGrapeFirstAudio()
    {
        Debug.Log("play mrs grape first audio");
        audioSource.PlayOneShot(mrsGrapeFirstAudio);
        mrsGrapeFirstSubtitle.SetActive(true);
    }

    void PlayMrGrapeFirstAudio()
    {
        Debug.Log("play mr grape first audio");
        audioSource.PlayOneShot(mrGrapeFirstAudio);
        mrGrapeFirstSubtitle.SetActive(true);
    }

    void PlayMrsGrapeSecondAudio()
    {
        Debug.Log("play mrs grape second audio");
        audioSource.PlayOneShot(mrsGrapeSecondAudio);
        mrsGrapeSecondSubtitle.SetActive(true);
    }

    void PlayMrGrapeSecondAudio()
    {
        Debug.Log("play mr grape second audio");
        audioSource.PlayOneShot(mrGrapeSecondAudio);
        mrsGrapeSecondSubtitle.SetActive(true);
    }

}
