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
        if (!doorObjectiveList.activeSelf){
            keyNotificationPopup.SetActive(true);
            keyObjectiveList.SetActive(true);
        }
        else if (doorObjectiveList.activeSelf){
            findKeyObjectiveCompleteIcon.SetActive(true);
            findKeyObjectiveComplete.SetActive(true);
        }
    }
}
