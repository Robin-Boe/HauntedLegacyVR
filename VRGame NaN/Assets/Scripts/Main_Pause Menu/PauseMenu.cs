using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Import Button Action & Player'head
    public InputActionReference toggleReference = null;
    public Transform head;
    public float spawnDistance = 1;

    // Menu Imports
    public GameObject MenuPage;
    public GameObject OptionsPage;
    public GameObject AreYouSure; 
    public GameObject ObjectivesPage;   
    public GameObject CollectablesPage;
      
    // Pause Count
    public int count = 0;
    public GameObject turn;
    public GameObject move;

    // Scene Loader Bool
    private bool scene_is_loading;

    // Scene loader for Exit to Main Menu
    public void LoadOtherScene(int index)
    {
        scene_is_loading = true;
        SceneManager.LoadScene(index);
    }

    public void ExitMenu(){
        // Enable Movement
        turn.SetActive(true);
        move.SetActive(true);
        count = 0;

        MenuPage.SetActive(false);
    }

    // Start is called before the first frame update
    void Menu(InputAction.CallbackContext context)
    {
        bool isActiveOptions = !MenuPage.activeSelf;

        // Sets the Menu page as active
        MenuPage.SetActive(isActiveOptions);

        // Puts the Menus in front of the player
        OptionsPage.transform.position = head.position + new Vector3(head.forward.x,0,head.forward.z).normalized / spawnDistance;
        AreYouSure.transform.position = head.position + new Vector3(head.forward.x,0,head.forward.z).normalized / spawnDistance;
        ObjectivesPage.transform.position = head.position + new Vector3(head.forward.x,0,head.forward.z).normalized / spawnDistance;
        CollectablesPage.transform.position = head.position + new Vector3(head.forward.x,0,head.forward.z).normalized / spawnDistance;

        // Disables movement and turn on click, enables when clicked again
        if (count == 0){
            //Time.timeScale = 0;
            turn.SetActive(false);
            move.SetActive(false);
            count = 1;
        }
        else if (count == 1){
            //Time.timeScale = 1;
            turn.SetActive(true);
            move.SetActive(true);
            count = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        toggleReference.action.started += Menu;
        
        // Changes the menu (one for each page) so they face the player at all times
        OptionsPage.transform.LookAt(new Vector3 (head.position.x, OptionsPage.transform.position.y, head.position.z));
        OptionsPage.transform.forward *= -1;

        AreYouSure.transform.LookAt(new Vector3 (head.position.x, AreYouSure.transform.position.y, head.position.z));
        AreYouSure.transform.forward *= -1;

        ObjectivesPage.transform.LookAt(new Vector3 (head.position.x, ObjectivesPage.transform.position.y, head.position.z));
        ObjectivesPage.transform.forward *= -1;

        CollectablesPage.transform.LookAt(new Vector3 (head.position.x, CollectablesPage.transform.position.y, head.position.z));
        CollectablesPage.transform.forward *= -1;
    }
}
