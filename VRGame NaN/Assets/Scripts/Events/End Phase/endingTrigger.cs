using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    private int firstTime = 0;

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
            Dirt.SetActive(false);
            Emily.SetActive(false);
        }
        else if (AllObjectsAreInactive())
        {
            Dirt.SetActive(true);
            // To avoid her repearing later when she is set to inactive
            if (firstTime == 0){
                Emily.SetActive(true);
                firstTime = 1;
            }
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
