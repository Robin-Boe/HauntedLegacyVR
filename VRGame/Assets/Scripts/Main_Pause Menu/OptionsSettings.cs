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

    // Gets Subtitle Gameobject
    public GameObject Subtitle;

    // Gets material used for glow and asigns colors
    public Material glowMaterial;
    public Color blue;
    public Color green;
    public Color red;
    public Color purple;
    public Color white;
    public Color black;

    // Load another scene function
    public void LoadOtherScene(int index)
    {
        scene_is_loading = true;
        SceneManager.LoadScene(index);
    }

    // Changes the type of turning the player has from 45 increments to continous turn (or vice versa)
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

    // Toggles on / off subtitles
    public void SetTypeSubtitleIndex(int index){
        if (index == 0){
            Subtitle.SetActive(true);
        }

        else if (index == 1){
            Subtitle.SetActive(false);
        }
    }

    // Change the highlight color
    public void ChangeColor(int index)
    {
        if (index == 0){
            glowMaterial.color = blue;
        }
        else if (index == 1){
            glowMaterial.color = green;
        }
        else if (index == 2){
            glowMaterial.color = red;
        }
        else if (index == 3){
            glowMaterial.color = purple;
        }
        else if (index == 4){
            glowMaterial.color = white;
        }
        else if (index == 5){
            glowMaterial.color = black;
        }
    }
}
