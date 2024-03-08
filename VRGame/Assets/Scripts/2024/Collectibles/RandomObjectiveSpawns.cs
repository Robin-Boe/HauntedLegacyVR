using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;

public class RandomObjectiveSpawns : MonoBehaviour
{
    // Collectables
    public GameObject mrPainting;
    public GameObject mrsPainting;
    public GameObject couplePainting;
    public GameObject workerPainting;
    public GameObject key;

    // Monsers
    public GameObject ghoul;
    public GameObject yokai;

    // Random Numbers
    int randomNumberMr;
    int randomNumberMrs;
    int randomNumberWorker;
    int randomNumberCouple;
    int randomNumberKey;
    int randomNumberGhoul;
    int randomNumberYokai;

    // Player Camera
    public GameObject player;

    // Keep players original position
    private Vector3 playerOrgPosition;

    // Blockage During Cutscene
    public GameObject blockageCouple;
    public GameObject blockageWorker;

    // Checks for testing which painting is active
    public GameObject Couple0;
    public GameObject Couple1;
    public GameObject Couple2;
    public GameObject Worker0;
    public GameObject Worker1;
    public GameObject Worker2;

    // Run the Couple Painting Sequence
    public void PrepareCouple()
    {
        playerOrgPosition = player.transform.position;
        Invoke("ChangePlayerCouple", 1.5f);
        Invoke("ReturnPlayerCouple", 29.5f);
    }

    public void PrepareWorker()
    {
        playerOrgPosition = player.transform.position;
        Invoke("ChangePlayerWorker", 1.5f);
        Invoke("ReturnPlayerWorker", 29.5f);
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

    // Teleport player back to original position for worker
    void ReturnPlayerCouple(){
        // If position is equally to index 0
        if (Couple0.activeSelf){
            player.GetComponent<XROrigin>().MoveCameraToWorldLocation(new Vector3(-1.102f, -3.9f, -23.182f));
        }
        // If position is equally to index 1
        else if (Couple1.activeSelf){
            player.GetComponent<XROrigin>().MoveCameraToWorldLocation(new Vector3(8.705f, 2.078f, -12.271f));
        }
        // If position is equally to index 2
        else if (Couple2.activeSelf){
            player.GetComponent<XROrigin>().MoveCameraToWorldLocation(new Vector3(-3.011f, 6.925f, -27.946f));
        }
        // If 3, then don't teleport as player already in basement
        blockageCouple.SetActive(false);
    }

    // Teleport player back to original position for worker
    void ReturnPlayerWorker(){
        // If position is equally to index 0
        if (Worker0.activeSelf){
            player.GetComponent<XROrigin>().MoveCameraToWorldLocation(new Vector3(3.79f, 6.925f, -14.014f));
        }
        // If position is equally to index 1
        else if (Worker1.activeSelf){
            player.GetComponent<XROrigin>().MoveCameraToWorldLocation(new Vector3(1.285f, -0.2f, -25.577f));
        }
        // If position is equally to index 2
        else if (Worker2.activeSelf){
            player.GetComponent<XROrigin>().MoveCameraToWorldLocation(new Vector3(-11.502f, -0.2f, -30.276f));
        }
        // If 3, then don't teleport as player already in attic
        blockageWorker.SetActive(false);
    }

    void decidePosition(int index, string collectable)
    {
        if (index == 0){
            if (collectable == "Mr"){
                mrPainting.transform.position = new Vector3(-7.665f, 7.327f, -12.994f);
            }
            else if (collectable == "Mrs"){
                mrsPainting.transform.position = new Vector3(-7.642f, 7.284f, -25.977f);
            }
            else if (collectable == "Couple"){
                couplePainting.transform.position = new Vector3(-1.468f, -4.502f, -22.244f);
                Couple0.SetActive(true);
            }
            else if (collectable == "Worker"){
                workerPainting.transform.position = new Vector3(3.944f, 6.131f, -12.6106f);
                Worker0.SetActive(true);
            }
            else if (collectable == "Key"){
                key.transform.position = new Vector3(2.139f, 2.053f, -12.7334f);
            }
        }

        else if (index == 1){
            if (collectable == "Mr"){
                mrPainting.transform.position = new Vector3(-5.161f, 3.919f, -15.687f);
            }
            else if (collectable == "Mrs"){
                mrsPainting.transform.position = new Vector3(12.383f, 7.005f, -17.854f);
            }
            else if (collectable == "Couple"){
                couplePainting.transform.position = new Vector3(8.603f, 1.497f, -10.538f);
                Couple1.SetActive(true);
            }
            else if (collectable == "Worker"){
                workerPainting.transform.position = new Vector3(0.671f, -0.871f, -21.894f);
                Worker1.SetActive(true);
            }
            else if (collectable == "Key"){
                key.transform.position = new Vector3(4.451f, 6.3305f, -17.1548f);
            }
        }
        
        else if (index == 2){
            if (collectable == "Mr"){
                mrPainting.transform.position = new Vector3(4.879f, -3.261f, -20.586f);
            }
            else if (collectable == "Mrs"){
                mrsPainting.transform.position = new Vector3(12.386f, 2.472f, -30.56f);
            }
            else if (collectable == "Couple"){
                couplePainting.transform.position = new Vector3(-2.278f, 6.017f, -26.646f);
                Couple2.SetActive(true);
            }
            else if (collectable == "Worker"){
                workerPainting.transform.position = new Vector3(-11.88f, -0.884f, -30.087f);
                Worker2.SetActive(true);
            }
            else if (collectable == "Key"){
                key.transform.position = new Vector3(9.854f, 6.5377f, -22.5858f);
            }
        }

        // If index == 3, the standard position (the position they are in the editor) is kept, and will not be changed
    }

    // Decice Monster Position
    void monsterPosition(int index, string monster)
    {
        if (index == 0){
            if (monster == "Ghoul"){
                ghoul.transform.position = new Vector3(-8.493f, 3.31f, -12.927f);
            }
            else if (monster == "Yokai"){
                yokai.transform.position = new Vector3(3.497f, -1.189f, -14.722f);
            }
        }
        else if (index == 1){
            if (monster == "Ghoul"){
                ghoul.transform.position = new Vector3(-5.197f, -1.179f, -11.847f);
            }
            else if (monster == "Yokai"){
                yokai.transform.position = new Vector3(13.711f, -1.189f, -3.864f);
            }
        }
        else if (index == 2){
            if (monster == "Ghoul"){
                ghoul.transform.position = new Vector3(10.921f, -1.179f, -12.45f);
            }
            else if (monster == "Yokai"){
                yokai.transform.position = new Vector3(7.175f, -3.709f, -6.75f);
            }
        }
        else if (index == 3){
            if (monster == "Ghoul"){
                ghoul.transform.position = new Vector3(10.138f, -3.69f, -4.517f);
            }
            else if (monster == "Yokai"){
                yokai.transform.position = new Vector3(-6.269f, -3.709f, -11.023f);
            }
        }
        else if (index == 4){
            if (monster == "Ghoul"){
                ghoul.transform.position = new Vector3(0.772f, -3.69f, -1.27f);
            }
            else if (monster == "Yokai"){
                yokai.transform.position = new Vector3(-0.988f, 3.358f, -14.236f);
            }
        }
        else if (index == 5){
            if (monster == "Ghoul"){
                ghoul.transform.position = new Vector3(-1.737f, -3.69f, -15.807f);
            }
            else if (monster == "Yokai"){
                yokai.transform.position = new Vector3(-7.621f, 3.358f, -0.76f);
            }
        }
        else if (index == 6){
            if (monster == "Ghoul"){
                ghoul.transform.position = new Vector3(3.55f, -7.186f, -9.557f);
            }
            else if (monster == "Yokai"){
                yokai.transform.position = new Vector3(1.017f, 1.809f, -8.933f);
            }
        }
        // If index == 7, keep the original position in editor (i.e. no change)
    }

    // Start is called before the first frame update
    void Start()
    {
        // Random number 0 - 3 for collectibles and 0 - 7 for monsters
        int randomNumberMr = Random.Range(0, 4);
        int randomNumberMrs = Random.Range(0, 4);
        int randomNumberCouple = Random.Range(0, 4);
        int randomNumberWorker = Random.Range(0, 4);
        int randomNumberKey = Random.Range(0, 4);
        int randomNumberGhoul = Random.Range(0, 8);
        int randomNumberYokai = Random.Range(0, 8);

        // Assign Objective Positions
        decidePosition(randomNumberMr, "Mr");
        decidePosition(randomNumberMrs, "Mrs");
        decidePosition(randomNumberCouple, "Couple");
        decidePosition(randomNumberWorker, "Worker");
        decidePosition(randomNumberKey, "Key");

        // Assign Monster Positions
        monsterPosition(randomNumberGhoul, "Ghoul");
        monsterPosition(randomNumberYokai, "Yokai");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
