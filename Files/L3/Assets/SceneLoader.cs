using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public int nextScenceLoader;
    public void LoadOtherScene(){
        SceneManager.LoadScene(nextScenceLoader);
    }
}