using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftExit : MonoBehaviour
{
    // Chimney + Audio + Cube
    public GameObject chimney;
    public GameObject audioFalling;
    public GameObject invisCube;

    // NPC
    public GameObject yokaiNPC;
    public GameObject ghoulNPC;

    // Paintings
    public GameObject man;
    public GameObject woman;
    public GameObject couple;
    public GameObject worker;

    void OnTriggerEnter (Collider other)
    {
        if ((other.gameObject.name == "XR Origin (XR Rig)") && ((!man.activeSelf) && (!woman.activeSelf) && (!worker.activeSelf) && (!couple.activeSelf))){
            chimney.GetComponent<Animator>().enabled = true;
            audioFalling.SetActive(true);
            invisCube.SetActive(true);
        }
    }
}
