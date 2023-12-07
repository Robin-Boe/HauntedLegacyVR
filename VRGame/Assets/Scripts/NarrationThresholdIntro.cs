using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationThresholdIntro : MonoBehaviour
{
    public GameObject check;

    void OnTriggerEnter (Collider other)
    {
        check.SetActive(true);
    }
}
