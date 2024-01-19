using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DisableEnableFlashlight : MonoBehaviour
{
    // Lights
    public GameObject light;

    // A Button Trigger
    public InputActionReference aButton = null;

    // A Button Pressed
    void Flashlight(InputAction.CallbackContext context){
        if (light.activeSelf){
            light.SetActive(false);
        }
        else if (!light.activeSelf){
            light.SetActive(true);
        } 
    }

    void Update()
    {
        aButton.action.started += Flashlight;
    }
}
