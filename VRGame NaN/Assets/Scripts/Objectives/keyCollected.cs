using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyCollected : MonoBehaviour
{
    // Enable Key Notficiaiton and List
    public GameObject keyNotificationPopup;
    public GameObject keyObjectiveList;

    // Check if door has ben interacted with
    public GameObject doorObjectiveList;
    public GameObject findKeyObjectiveComplete;
    public GameObject findKeyObjectiveCompleteIcon;

    // Update is called once per frame
    public void KeyNotification()
    {
        // IF door has not been interacted with
        if (!doorObjectiveList.activeSelf){
            // Set notification (find door) to active
            keyNotificationPopup.SetActive(true);
            // Set objective (find door) to active
            keyObjectiveList.SetActive(true);
        }
        // IF the door has been interacted with
        else if (doorObjectiveList.activeSelf){
            // Set find key objective (checkmark) to active
            findKeyObjectiveCompleteIcon.SetActive(true);
            // Set objective notification (find key) to active
            findKeyObjectiveComplete.SetActive(true);
        }
    }
}
