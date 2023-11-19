using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introScene : MonoBehaviour
{
    public GameObject Car;
    public int nextSceneIndex;
    private bool scene_is_loading;

    // Start is called before the first frame update
    void LoadOtherScene()
    {
        scene_is_loading = true;
        SceneManager.LoadScene(nextSceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Car.transform.position.x > -3.36f && Car.transform.position.x < -2.06f) && (Car.transform.position.z > 52.02f && Car.transform.position.x < 54.29f)){
            if(!scene_is_loading)
                LoadOtherScene();
        }
    }
}
