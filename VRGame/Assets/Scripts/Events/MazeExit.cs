using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeExit : MonoBehaviour
{
    public GameObject objectiveActive;
    public GameObject newExitCompleteNotification;
    public GameObject newExitIconComplete;

    void OnTriggerEnter (Collider other)
    {
        if ((other.gameObject.name == "XR Origin (XR Rig)") && (objectiveActive.activeSelf)){
            newExitCompleteNotification.SetActive(true);
            newExitIconComplete.SetActive(true);
        }
    }
}
