using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnThreshold : MonoBehaviour
{
    public GameObject objectActivate;
    public GameObject enterMansion;

    void OnTriggerEnter (Collider other)
    {
        if ((other.gameObject.name == "XR Origin (XR Rig)") && (!enterMansion.activeSelf)){
            objectActivate.SetActive(true);
        }
    }

    void OnTriggerExit (Collider other)
    {
        if ((other.gameObject.name == "XR Origin (XR Rig)") && (!enterMansion.activeSelf)){
            objectActivate.SetActive(false);
        }        
    }
}
