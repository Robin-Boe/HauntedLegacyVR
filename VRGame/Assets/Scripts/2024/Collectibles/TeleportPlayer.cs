using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class TeleportPlayer : MonoBehaviour
{
    // Player Camera
    public GameObject player;

    // Keep players original position
    private Vector3 playerOrgPosition;

    // Blockage During Cutscene
    public GameObject blockageCouple;
    public GameObject blockageWorker;

    // Run the Couple Painting Sequence
    public void PrepareCouple()
    {
        playerOrgPosition = player.transform.position;
        Invoke("ChangePlayerCouple", 1.5f);
        Invoke("ReturnPlayer", 29.5f);
    }

    public void PrepareWorker()
    {
        playerOrgPosition = player.transform.position;
        Invoke("ChangePlayerWorker", 1.5f);
        Invoke("ReturnPlayer", 29.5f);
    }

    // Teleport player to basement
    void ChangePlayerCouple(){
        player.GetComponent<XROrigin>().MoveCameraToWorldLocation(new Vector3(-8.697f, -0.2f, -17.489f));
        blockageCouple.SetActive(true);
    } 

    // Teleport player to attic
    void ChangePlayerWorker(){
        player.GetComponent<XROrigin>().MoveCameraToWorldLocation(new Vector3(0.563f, 10f, -16.382f));
        blockageWorker.SetActive(true);
    } 

    // Teleport player back to original position
    void ReturnPlayer(){
        player.GetComponent<XROrigin>().MoveCameraToWorldLocation(playerOrgPosition);
        blockageCouple.SetActive(false);
        blockageWorker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
