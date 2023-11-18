using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectPaintings : MonoBehaviour
{
    // Items
    public GameObject Couple;
    public GameObject Woman;
    public GameObject Man;
    public GameObject Worker;
    public GameObject Key;
    public GameObject Crystal;

    // Counters
    public GameObject Zero;
    public GameObject One;
    public GameObject Two;
    public GameObject Three;
    public GameObject Four;

    // Check Actives
    public GameObject CoupleActive;
    public GameObject WomanActive;
    public GameObject ManActive;
    public GameObject WorkerActive;
    public GameObject KeyActive;
    public GameObject CrystalActive;

    int count = 0;
    //Vector3 scaleChange = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Woman Paiting is Selected
    void womanPainting()
    {
        // Disables Painting
        //Woman.transform.localScale = scaleChange;
        Woman.SetActive(false);

        // Increases the Size for Update Counter
        count += 1;

        // Disables Cube To Avoid Action Repating
        WomanActive.SetActive(false);
    }

    // Couple Paiting is Selected
    void coupleActive()
    {
        // Disables Painting
        //Couple.transform.localScale = scaleChange;
        Couple.SetActive(false);

        // Increases the Size for Update Counter
        count += 1;

        // Disables Cube To Avoid Action Repating
        CoupleActive.SetActive(false);
    }

    // Man Paiting is Selected
    void manActive()
    {
        // Disables Painting
        //Man.transform.localScale = scaleChange;
        Man.SetActive(false);

        // Increases the Size for Update Counter
        count += 1;

        // Disables Cube To Avoid Action Repating
        ManActive.SetActive(false);
    }

    // Worker Paiting is Selected
    void workerActive()
    {
        // Disables Painting
        //Worker.transform.localScale = scaleChange;
        Worker.SetActive(false);

        // Increases the Size for Update Counter
        count += 1;

        // Disables Cube To Avoid Action Repating
        WorkerActive.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Woman Painting Collected
        if ((WomanActive.activeSelf)){
            womanPainting();
        }

        // Couple Painting Collected
        if ((CoupleActive.activeSelf)){
            coupleActive();
        }

        // Man Painting Collected
        if ((ManActive.activeSelf)){
            manActive();
        }

        // Man Painting Collected
        if ((WorkerActive.activeSelf)){
            workerActive();
        }

        // Inventory Update Counter
        if ((count == 1) && (Zero.activeSelf)){
            Zero.SetActive(false);
            One.SetActive(true);
        }
        else if ((count == 2) && (One.activeSelf)){
            One.SetActive(false);
            Two.SetActive(true);
        }
        else if ((count == 3) && (Two.activeSelf)){
            Two.SetActive(false);
            Three.SetActive(true);
        }
        else if ((count == 4) && (Three.activeSelf)){
            Three.SetActive(false);
            Four.SetActive(true);
        }
    }
}
