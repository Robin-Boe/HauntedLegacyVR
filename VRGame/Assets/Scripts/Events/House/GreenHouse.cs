using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenHouse : MonoBehaviour
{
    // NPC
    public GameObject girl;
    public GameObject boy;

    /// If player leaves the box collider
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name == "XR Origin (XR Rig)"){
            girl.SetActive(false);
            boy.SetActive(false);
        }
    }

    /// If player leaves the box collider
    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.name == "XR Origin (XR Rig)"){
            girl.SetActive(true);
            boy.SetActive(true);
        }
    }
}
