using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWorker : MonoBehaviour
{
    // NPC
    public GameObject worker;

    /// If player leaves the box collider
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name == "XR Origin (XR Rig)"){
            worker.SetActive(false);
        }
    }

    /// If player leaves the box collider
    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.name == "XR Origin (XR Rig)"){
            worker.SetActive(true);
        }
    }
}
