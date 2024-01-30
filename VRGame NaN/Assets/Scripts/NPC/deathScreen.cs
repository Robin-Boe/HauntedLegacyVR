using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScreen : MonoBehaviour
{
    public Transform head;
    public GameObject DeathScreen;

    // Scene Loader Bool
    private bool scene_is_loading;

    // Scene loader for Death Screen
    public void LoadOtherScene(int index)
    {
        scene_is_loading = true;
        SceneManager.LoadScene(index);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DeathScreen.transform.position = head.position - new Vector3(0,0,-0.45f);  
    }
}
