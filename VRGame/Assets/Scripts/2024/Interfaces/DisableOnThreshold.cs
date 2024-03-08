using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnThreshold : MonoBehaviour
{
    public GameObject objectActivate;

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name == "XR Origin (XR Rig)"){
            objectActivate.SetActive(true);
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.name == "XR Origin (XR Rig)"){
            objectActivate.SetActive(false);
        }        
    }
}
