using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftDoorClosing : MonoBehaviour
{
    // Player
    public GameObject Player;

    // Doors
    public Animator leftDoorAnim;
    public BoxCollider leftDoorCollider;
    int doorCheck = 0;

    // Start is called before the first frame update
    /*void Start()
    {
        leftDoorAnim = GetComponent<Animator>();
    }

    // Door closing sequence 
    void doorClose()
    {
        leftDoorAnim.Play("doorClosingLeft");
        leftDoorCollider.enabled = true;
    }*/

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.y == 0){
            leftDoorCollider.enabled = true;
        }          
        /*// If the player enters the mansion within certain positions than  
        if ((Player.transform.position.x <= 2.896436f && Player.transform.position.x >= -3.542453f) && (Player.transform.position.y >= 0 && Player.transform.position.y <= 2) && (Player.transform.position.z <= -6.5f && Player.transform.position.z >= -9.0f) && (doorCheck == 0)){
            doorCheck = 1;
            doorClose();
        }*/
    }
}
