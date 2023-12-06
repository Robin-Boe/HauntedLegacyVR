using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioTriggers : MonoBehaviour
{
    // Player
    public GameObject Player;

    // Doors
    int doorCheck = 0;
    public AudioSource closeDoor;
    public AudioClip windClose;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Door closing sequence 
    void doorClose()
    {
        closeDoor.PlayOneShot(windClose);
    }

    // Update is called once per frame
    void Update()
    {       
        // If the player enters the mansion within certain positions than  
        if ((Player.transform.position.x <= 2.896436f && Player.transform.position.x >= -3.542453f) && (Player.transform.position.y >= 0 && Player.transform.position.y <= 2) && (Player.transform.position.z <= -6.5f && Player.transform.position.z >= -9.0f) && (doorCheck == 0)){
            doorCheck = 1;
            doorClose();
        }
    }
}
