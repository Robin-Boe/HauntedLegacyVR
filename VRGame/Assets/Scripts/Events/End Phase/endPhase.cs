using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endPhase : MonoBehaviour
{
    // Paintings 
    public GameObject mrPainting;
    public GameObject mrsPainting;
    public GameObject workerPainting;
    public GameObject couplePainting;

    // Monsters
    public GameObject ghoul;
    public GameObject yokai;

    // Timer
    private float timer = 40;

    // Notifications
    public GameObject fourPaintingsNotificationComplete;
    public GameObject fourPaintingsIconComplete;
    public GameObject leavePropertyNotification;
    public GameObject leavePropertyObjectiveList;

    // Update is called once per frame
    void Update()
    {
        if ((!mrPainting.activeSelf) && (!mrsPainting.activeSelf) && (!workerPainting.activeSelf) && (!couplePainting.activeSelf)){
            timer -= Time.deltaTime;
            if (timer <= 0.0f){
                ghoul.SetActive(true);
                yokai.SetActive(true);
            }
            else if (timer <= 8.0f){
                fourPaintingsNotificationComplete.SetActive(true);
                fourPaintingsIconComplete.SetActive(true);
                leavePropertyNotification.SetActive(true);
                leavePropertyObjectiveList.SetActive(true);
            }      
        }
    }
}
