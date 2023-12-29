using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    public GameObject Couple;
    public GameObject Woman;
    public GameObject Man;
    public GameObject Worker;
    public GameObject Dirt;

    void CheckObjectStatus()
    {
        if (AllObjectsAreActive())
        {
            Debug.Log("All game objects are active!");
            Dirt.SetActive(false);
        }
        else if (AllObjectsAreInactive())
        {
            Debug.Log("All game objects are inactive!");
            Dirt.SetActive(true);
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
