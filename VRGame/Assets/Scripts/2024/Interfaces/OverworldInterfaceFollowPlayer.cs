using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldInterfaceFollowPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject overworldInterface;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Panel itself
        overworldInterface.transform.rotation = Quaternion.LookRotation(player.transform.position - overworldInterface.transform.position);
        overworldInterface.transform.forward *= -1;

        // Button
        button.transform.rotation = Quaternion.LookRotation(player.transform.position - button.transform.position);
        button.transform.forward *= -1;
    }
}
