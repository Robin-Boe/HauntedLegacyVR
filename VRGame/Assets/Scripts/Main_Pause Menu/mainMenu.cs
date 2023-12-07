using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    private bool scene_is_loading;

    // Menu Settings
    public GameObject MenuPage;
    public Transform head;
    public float spawnDistance;

    // Start is called before the first frame update
    public void LoadOtherScene(int index)
    {
        scene_is_loading = true;
        SceneManager.LoadScene(index);
    }

    void Start(){
        MenuPage.transform.position = head.position + new Vector3(head.forward.x,0.25f,head.forward.z).normalized * spawnDistance;
    }

    // Update is called once per frame
    void Update()
    {
        MenuPage.transform.LookAt(new Vector3 (head.position.x, MenuPage.transform.position.y, head.position.z));
        MenuPage.transform.forward *= -1;
    }
}
