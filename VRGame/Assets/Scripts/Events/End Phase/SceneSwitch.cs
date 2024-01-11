using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        // Switch scene after 10 seconds
        Invoke("SwitchScene", 10.0f);
    }

    private void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}