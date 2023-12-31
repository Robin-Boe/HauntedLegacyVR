using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    public GameObject Couple;
    public GameObject Woman;
    public GameObject Man;
    public GameObject Worker;
    public GameObject Dirt;
    public GameObject Emily;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AllObjectsAreActive())
        {
            Debug.Log("All game objects are active!");
            Dirt.SetActive(false);
            Emily.SetActive(false);
        }
        else if (AllObjectsAreInactive())
        {
            Debug.Log("All game objects are inactive!");
            Dirt.SetActive(true);
            Emily.SetActive(true);
        }
    }

    bool AllObjectsAreActive()
    {
        return Couple.activeSelf && Woman.activeSelf && Man.activeSelf && Worker.activeSelf;
    }

    bool AllObjectsAreInactive()
    {
        return !Couple.activeSelf && !Woman.activeSelf && !Man.activeSelf && !Worker.activeSelf;
    }
}
