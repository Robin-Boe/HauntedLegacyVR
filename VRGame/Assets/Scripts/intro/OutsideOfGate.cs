using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideOfGate : MonoBehaviour
{
    // Player Controls 
    public GameObject locomotion;
    public GameObject player;
    
    // Timer
    private float timer = 13.0f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f){
            locomotion.SetActive(true);
            player.GetComponent<Animator>().enabled = false;
        }
    }
}
