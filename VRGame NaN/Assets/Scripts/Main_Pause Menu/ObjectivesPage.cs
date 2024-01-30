using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesPage : MonoBehaviour
{
    // Objectives Buttons
    public GameObject mrGrape;
    public GameObject mrsGrape;
    public GameObject couple;
    public GameObject worker;
    public GameObject findNewExit;
    public GameObject findADoor;
    public GameObject findAKey;
    public GameObject leaveTheProperty;

    // Arrows for 4 Paintings
    public GameObject arrowDown;
    public GameObject arrowSide;

    // Start is called before the first frame update
    public void paintingsButtonPressed()
    {
        //IF OPEN
        if (arrowDown.activeSelf){
            arrowSide.SetActive(true);
            arrowDown.SetActive(false);

            //Disable the subobjectives
            mrGrape.SetActive(false);
            mrsGrape.SetActive(false);
            couple.SetActive(false);
            worker.SetActive(false);

            // If player interacted with the door and "Find A new Exit Point" objective is active
            if (findNewExit.activeSelf){
                findNewExit.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, 74.24f, 1.1f);
                findADoor.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, 31f, 1.1f);
                findAKey.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, 31f, 1.1f);
                leaveTheProperty.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, -12.52f, 1.1f);
            }
            // If player did not interact with the door and "fina a new exit point" objective is inactive
            else{
                findADoor.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, 74.24f, 1.1f);
                findAKey.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, 74.24f, 1.1f);
                leaveTheProperty.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, 31f, 1.1f);
            }
        }
        // IF CLOSED
        else if (arrowSide.activeSelf){
            arrowSide.SetActive(false);
            arrowDown.SetActive(true);

            //Disable the subobjectives
            mrGrape.SetActive(true);
            mrsGrape.SetActive(true);
            couple.SetActive(true);
            worker.SetActive(true);

            // If player interacted with the door and "Find A new Exit Point" objective is active
            if (findNewExit.activeSelf){
                findNewExit.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, -88.9f, 1.1f);
                findADoor.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, -131.9f, 1.1f);
                findAKey.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, -131.9f, 1.1f);
                leaveTheProperty.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, -175.4f, 1.1f);
            }
            // If player did not interact with the door and "fina a new exit point" objective is inactive
            else{
                findADoor.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, -88.9f, 1.1f);
                findAKey.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, -88.9f, 1.1f);
                leaveTheProperty.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, -131.9f, 1.1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If player interacted with the door and "Find A new Exit Point" objective is active and 4 paintings is open
        if ((findNewExit.activeSelf) && (arrowDown.activeSelf)){
            findNewExit.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, -88.9f, 1.1f);
            findADoor.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, -131.9f, 1.1f);
            findAKey.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, -131.9f, 1.1f);
            leaveTheProperty.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, -175.4f, 1.1f);
        }
        // If player did not interact with the door and "fina a new exit point" objective is inactive and 4 paintings is open
        else if ((!findNewExit.activeSelf) && (arrowDown.activeSelf)){
            findADoor.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, -88.9f, 1.1f);
            findAKey.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, -88.9f, 1.1f);
            leaveTheProperty.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, -131.9f, 1.1f);
        }
        // If player interacted with the door and "Find A new Exit Point" objective is active and 4 paintings is not open
        else if ((findNewExit.activeSelf) && (!arrowDown.activeSelf)){
            findNewExit.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, 74.24f, 1.1f);
            findADoor.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, 31f, 1.1f);
            findAKey.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, 31f, 1.1f);
            leaveTheProperty.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, -12.52f, 1.1f);
        }
        // If player did not interact with the door and "fina a new exit point" objective is inactive and 4 paintings is not open
        else if ((!findNewExit.activeSelf) && (!arrowDown.activeSelf)){
            findADoor.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, 74.24f, 1.1f);
            findAKey.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, 74.24f, 1.1f);
            leaveTheProperty.GetComponent<RectTransform>().localPosition = new Vector3(39.1f, 31f, 1.1f);
        }
    }
}
