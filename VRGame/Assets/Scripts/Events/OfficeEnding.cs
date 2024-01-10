using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OfficeEnding : MonoBehaviour
{
    // XR & Locomotion
    public GameObject head;
    public GameObject locomotion;

    // NPCS
    public GameObject ghost;

    // Fade In And Out
    public GameObject fadeInAndOut;

    // Animations
    public Animator door;
    public Animator chair;

    // Audio
    private int audioCheck = 0;
    public GameObject playerDialog;
    public GameObject doorAudio;
    public GameObject chairAudio;
    public AudioSource ghostAudio;
    public AudioClip ghostClip;

    // Subtitles
    public GameObject subtitle;
    public TMP_Text subtitleText;

    // Timer
    private int timerCheck = 0;
    private float timer = 17.0f; 

    void PlayAudio(){
        ghostAudio.PlayOneShot(ghostClip);
        subtitle.SetActive(true);
    }

    // Load to Main Menu
    void LoadOtherScene()
    {
        SceneManager.LoadScene(0);
    }

    // When the player enters the threshold
    void OnTriggerEnter (Collider other)
    {
        // To start sequence in Update
        timerCheck = 1;

        playerDialog.SetActive(true);
        locomotion.SetActive(false);
        subtitle.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (timerCheck == 1){
            timer -= Time.deltaTime;

            // --- EVENT --- 
            // 19 seconds in
            if (timer <= -7.0f){
                LoadOtherScene();
            }
            // 17 seconds in
            else if (timer <= -2.0f){
                ghost.transform.position = new Vector3(head.transform.position.x, ghost.transform.position.y, head.transform.position.z - 0.8f); 
                if (audioCheck == 2){
                    PlayAudio();
                    audioCheck = 3;
                } 
            }
            // 14.5 seconds in
            else if (timer <= 0.5f){
                ghost.transform.position = new Vector3(head.transform.position.x - 0.5f, ghost.transform.position.y, head.transform.position.z - 2.0f); 
                subtitle.SetActive(false);
            }
            // 11.5 seconds in
            else if (timer <= 3.5f){
                ghost.transform.position = new Vector3(head.transform.position.x - 1f, ghost.transform.position.y, head.transform.position.z - 3.0f);
                if (audioCheck == 1){
                    PlayAudio();
                    audioCheck = 2;
                } 
            }
            // 10 seconds in
            else if (timer <= 5.0f){
                fadeInAndOut.SetActive(true);
                subtitle.SetActive(false);
            }

            // Set door to close and activate ghost at 7 seconds into the scene
            else if (timer <= 8.0f){
                // Ghost
                ghost.SetActive(true);
                if (audioCheck == 0){
                    PlayAudio();
                    audioCheck = 1;
                }

                // Door Closing
                door.enabled = true;
                doorAudio.SetActive(true);
            } 
            // Set chair animation and sound to active at 6 seconds into the scene
            else if (timer <= 9.5f){
                chair.enabled = true;
                chairAudio.SetActive(true);
            }

            // --- SUBTITLES ---

            if (timer <= 7.5f){
                subtitleText.text = @"<b>???:</b> Those paintings are not yours..."; 
            }
            else if (timer <= 9.0f){
               subtitleText.text = @"<b>PLAYER:</b> Chief...?"; 
            }
            else if (timer <= 11.0f){
               subtitleText.text = @"<b>PLAYER:</b> But I collected at least some of them"; 
            }
            else if (timer <= 13.5f){
               subtitleText.text = @"<b>PLAYER:</b> but I couldn't retrieve all the paintings."; 
            }
            else if (timer <= 15.5f){
               subtitleText.text = @"<b>PLAYER:</b> Please don't get upset..."; 
            }
        }
    }
}
