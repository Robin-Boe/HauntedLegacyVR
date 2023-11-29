using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    // Import Button Action & Player'head
    public InputActionReference toggleReference = null;
    public Transform head;
    public float spawnDistance = 1;

    // Menu Imports
    public GameObject MenuPage;
    public GameObject OptionsPage;
    public GameObject ObjectivesPage;   
    public GameObject CollectablesPage;   
    
    // Start is called before the first frame update
    void Menu(InputAction.CallbackContext context)
    {
        bool isActiveOptions = !MenuPage.activeSelf;

        // Sets the Menu page as active
        MenuPage.SetActive(isActiveOptions);

        // Puts the Menus in front of the player
        OptionsPage.transform.position = head.position + new Vector3(head.forward.x,0,head.forward.z).normalized / spawnDistance;
        ObjectivesPage.transform.position = head.position + new Vector3(head.forward.x,0,head.forward.z).normalized / spawnDistance;
        CollectablesPage.transform.position = head.position + new Vector3(head.forward.x,0,head.forward.z).normalized / spawnDistance;   
    }

    // Update is called once per frame
    void Update()
    {
        toggleReference.action.started += Menu;
        
        // Changes the menu (one for each page) so they face the player at all times
        OptionsPage.transform.LookAt(new Vector3 (head.position.x, OptionsPage.transform.position.y, head.position.z));
        OptionsPage.transform.forward *= -1;

        ObjectivesPage.transform.LookAt(new Vector3 (head.position.x, ObjectivesPage.transform.position.y, head.position.z));
        ObjectivesPage.transform.forward *= -1;

        CollectablesPage.transform.LookAt(new Vector3 (head.position.x, CollectablesPage.transform.position.y, head.position.z));
        CollectablesPage.transform.forward *= -1;
    }
}
