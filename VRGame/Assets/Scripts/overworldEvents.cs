using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overworldEvents : MonoBehaviour
{
    // Player
    public GameObject Player;

    // Doors
    int doorCheck = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Door closing sequence 
    void doorClose()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        // If the player enters the mansion within certain positions than  
        if ((Player.transform.position.x <= 2.896436f && Player.transform.position.x >= -3.542453f) && (Player.transform.position.y >= 1.0f && Player.transform.position.y <= 1.026535f) && (Player.transform.position.z <= -6.650888f && Player.transform.position.z >= -7.250888f) && (doorCheck == 0)){
            doorCheck = 1;
            doorClose();
        }
    }
}
