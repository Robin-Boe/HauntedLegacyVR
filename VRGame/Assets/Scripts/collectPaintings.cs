using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public GameObject KeyDisplay;

    // Check Actives
    public GameObject CoupleActive;
    public GameObject WomanActive;
    public GameObject ManActive;
    public GameObject WorkerActive;
    public GameObject KeyActive;
    public GameObject CrystalActive;

    int count = 0;
    
    // Text To Change in Collectables Menu
    public TMP_Text collectablesText;

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

    // Key is Selected
    void keyActive()
    {
        // Disables Key
        Key.SetActive(false);

        // Enables Key Display
        KeyDisplay.SetActive(true);

        // Disables Cube To Avoid Action Repating
        KeyActive.SetActive(false);
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

        // Key Collected
        if ((KeyActive.activeSelf)){
            keyActive();
        }

        // Inventory Update Counter
        if ((count == 1)){
            //Zero.SetActive(false);
            //One.SetActive(true);
            collectablesText.text = "(1 / 4)";
        }
        else if ((count == 2)){
            //One.SetActive(false);
            //Two.SetActive(true);
            collectablesText.text = "(2 / 4)";
        }
        else if ((count == 3)){
            //Two.SetActive(false);
            //Three.SetActive(true);
            collectablesText.text = "(3 / 4)";
        }
        else if ((count == 4)){
            //Three.SetActive(false);
            //Four.SetActive(true);
            collectablesText.text = "(4 / 4)";
        }
    }
}
