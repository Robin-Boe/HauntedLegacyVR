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
    public GameObject CollectablesPage;   

    // Start is called before the first frame update
    void Menu(InputAction.CallbackContext context)
    {
        // Sets the objects as active
        bool isActiveOptions = !MenuPage.activeSelf;

        MenuPage.SetActive(isActiveOptions);

        OptionsPage.transform.position = head.position + new Vector3(head.forward.x,0,head.forward.z).normalized / spawnDistance;
        CollectablesPage.transform.position = head.position + new Vector3(head.forward.x,0,head.forward.z).normalized / spawnDistance;
    }

    // Update is called once per frame
    void Update()
    {
        toggleReference.action.started += Menu;
        OptionsPage.transform.LookAt(new Vector3 (head.position.x, OptionsPage.transform.position.y, head.position.z));
        OptionsPage.transform.forward *= -1;

        CollectablesPage.transform.LookAt(new Vector3 (head.position.x, CollectablesPage.transform.position.y, head.position.z));
        CollectablesPage.transform.forward *= -1;
    }
}
