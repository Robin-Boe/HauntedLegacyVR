using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    private GameObject destination;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        while (true)
        {
            destination = GameObject.FindGameObjectWithTag("MainCamera");
            agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(destination.transform.position);
            yield return new WaitForSeconds(1);
        }
    }
}