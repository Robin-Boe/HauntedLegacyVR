using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneSwitcher : MonoBehaviour
{
  
    public InputAction leftHand_Action; 
    public InputAction rightHand_Action; 

    public int nextSceneIndex;

    private bool scene_is_loading;
    
    void OnEnable() 
    {
       if(leftHand_Action != null)   
        leftHand_Action.Enable();  
         if(rightHand_Action != null)   
        rightHand_Action.Enable();     
    }
    void OnDisable() 
    {
        leftHand_Action.Disable(); 
        rightHand_Action.Disable(); 

    }  
    private void Update()
    {
        if (leftHand_Action.inProgress && rightHand_Action.inProgress )
        {
            if(!scene_is_loading)
            LoadOtherScene();
        }
    } 
    public void LoadOtherScene()  // call this function to load scene
    {
        scene_is_loading = true;
        SceneManager.LoadScene(nextSceneIndex);
    }
   
 

    
}