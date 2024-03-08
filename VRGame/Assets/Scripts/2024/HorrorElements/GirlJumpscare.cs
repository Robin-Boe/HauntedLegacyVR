using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlJumpscare : MonoBehaviour
{
    // girl
    public GameObject girl;

    // check (to see if trigger has been activated)
    public GameObject check;

    void GirlJumpscareDeactivate(){
        girl.SetActive(false);
    }

    // When the player enters
    void OnTriggerEnter (Collider other)
    {
        if ((other.gameObject.name == "XR Origin (XR Rig)") && (!check.activeSelf)){
            girl.SetActive(true);
            check.SetActive(true);
            Invoke("GirlJumpscareDeactivate", 2.3f);
        }
        
    }
}
