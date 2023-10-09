using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurnOnLight : MonoBehaviour
{
    public InputAction anyBtn;
    public GameObject anyObject;
    // Start is called before the first frame update
    void Start()
    {
        anyBtn.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (anyBtn.WasPerformedThisFrame())
        {
            Debug.Log("A Button on gamepad was hold for one second");
            if(anyObject.activeSelf)
            anyObject.SetActive(false);
            else if (!anyObject.activeSelf)
            anyObject.SetActive(true);
        }
    }
}
