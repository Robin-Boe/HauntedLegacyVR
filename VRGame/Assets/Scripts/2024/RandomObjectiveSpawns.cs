using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectiveSpawns : MonoBehaviour
{
    int randomNumberMrs;
    int randomNumberMr;
    int randomNumberWorker;
    int randomNumberCouple;
    int randomNumberKey;


    // Start is called before the first frame update
    void Start()
    {
        // Random number
        int randomNumberMrs = Random.Range(0, 3);
        int randomNumberMr = Random.Range(0, 3);
        int randomNumberWorker = Random.Range(0, 3);
        int randomNumberCouple = Random.Range(0, 3);
        int randomNumberKey = Random.Range(0, 3);

        // Debug.Log("Mrs" + randomNumberMrs);
        // Debug.Log("Mr" + randomNumberMr);
        // Debug.Log("Worker" + randomNumberWorker);
        // Debug.Log("Couple" + randomNumberCouple);
        // Debug.Log("Key" + randomNumberKey);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
