using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightUpgrade : MonoBehaviour
{
    public Light flashlight; 

    // Start is called before the first frame update
    void Start()
    {
        flashlight = GetComponent<Light>();
    }

    public void upgradeFlashlight()
    {
        flashlight.range = 15.0f;
    }
}
