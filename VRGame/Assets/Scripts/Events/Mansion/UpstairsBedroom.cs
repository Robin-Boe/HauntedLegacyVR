using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpstairsBedroom : MonoBehaviour
{
    public GameObject witch;

    private int timerCheck = 0;
    private int initalCheck = 1;
    private float timer = 16.0f;

    // When the player enters the threshold
    void OnTriggerEnter (Collider other)
    {
        if (initalCheck == 1){
            timerCheck = 1;
            witch.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timerCheck == 1){
            timer -= Time.deltaTime;

            if (timer <= 0.0f){
                witch.SetActive(false);
                timerCheck = 2;
            }
        }
    }
}
