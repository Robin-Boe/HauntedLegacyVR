using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.SceneManagement;

public class OptionsSettings : MonoBehaviour
{
    private bool scene_is_loading;

    // Gets the turn components
    public ActionBasedSnapTurnProvider snapTurn;
    public ActionBasedContinuousTurnProvider continuousTurn;
    public GameObject RightControll;

    // Gets the tunnel gameobject
    public GameObject Tunnel;

    public void LoadOtherScene(int index)
    {
        scene_is_loading = true;
        SceneManager.LoadScene(index);
    }

    public void SetTypeFromTurnIndex(int index){
        //Enables smooth turning
        if (index == 0){
            RightControll.GetComponent<ActionBasedControllerManager>().smoothTurnEnabled = true;
            snapTurn.enabled = false;
            continuousTurn.enabled = true;
        }

        //Enables Snap Turning
        else if (index == 1){
            RightControll.GetComponent<ActionBasedControllerManager>().smoothTurnEnabled = false;
            snapTurn.enabled = true;
            continuousTurn.enabled = false;
        }
    }

    // Toggles on / off the tunnel vision gameobject
    public void SetTypeFromTunnelIndex(int index){
        if (index == 0){
            Tunnel.SetActive(true);
        }

        else if (index == 1){
            Tunnel.SetActive(false);
        }
    }
}
