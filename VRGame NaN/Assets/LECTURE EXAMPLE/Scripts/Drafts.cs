using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Drafts : MonoBehaviour
{
    private Camera mainCamera;

    public GameObject anyObject;

    public InputAction anyAction;  // more tutorials for InputSystem: https://www.kodeco.com/9671886-new-unity-input-system-getting-started

    public Vector3 resetPosition = new Vector3();

    void Awake()
    {
        anyAction.performed += OnAnyAction;
    }
   void OnEnable()  //this is called when unity is started in case it is active or if this is manually activated
    {
       if(anyAction != null)   // only call this if an InputAction is assigned
        anyAction.Enable();     // activate the inputAction binding, otherwise ...not working!
    }

    void OnDisable() //this is called when unity is paused or this is manually deactivated
    {
        anyAction.Disable(); //need to disable, otherwise ...amagedon!
    }
    void Start()
    {
        mainCamera = Camera.main;   // get the main camera of this scene
    }

    public void ChangeCameraToColour()
    {

        mainCamera.clearFlags = CameraClearFlags.SolidColor;    //set camera to render solidColour
        mainCamera.backgroundColor = Color.blue;        // Set the background color of the camera
    }
    public void ChangeCameraToSkybox()
    {
        mainCamera.clearFlags = CameraClearFlags.Skybox; //set camera to render Skybox

    }
    public void HideObject()
    {
        anyObject.SetActive(false); //deactivate the assigned object
    }
    public void ShowObject()
    {
        anyObject.SetActive(true); //activate the assigned object
    }  
    public void LoadOtherScene(int nextSceneIndex)  // call this function and pass an integer to load scene
    {
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void OnAnyAction(InputAction.CallbackContext context)
    {
    //here you can write code that should be executed when the inputAction that you assigned in the inspector is performed.
        
    //e.g. 1) a switch for hiding/showing the referenced gameObject "anyObject"
    /*
        if(anyObject.activeSelf)
        {
            HideObject();
        }
        else if(!anyObject.activeSelf)
        {
            ShowObject();
        }
    */

    //... or 2) resetting an assigned object to a certain position
    /* 
        ResetToPosition();
    */

    }

    private void ResetToPosition()
    {
        anyObject.transform.position = resetPosition;
    }
  

 
    
}