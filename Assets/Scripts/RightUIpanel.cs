using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] objects = new GameObject[9]; // Array to hold 9 objects

    void Start()
    {
        DisableAllObjects(); // Disable all objects at the start
    }

    public void EnableObject(int index)
    {
        if (index >= 0 && index < objects.Length && objects[index] != null)
        {
            objects[index].SetActive(true);
        }
    }

    public void DisableObject(int index)
    {
        if (index >= 0 && index < objects.Length && objects[index] != null)
        {
            objects[index].SetActive(false);
        }
    }

    public void EnableAllObjects()
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }

    public void DisableAllObjects()
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }
}
