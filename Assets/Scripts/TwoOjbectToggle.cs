using UnityEngine;

public class TwoObjToggle : MonoBehaviour
{
    // Drag the two objects in the Inspector
    public GameObject object1;
    public GameObject object2;

    // Function to enable object1
    public void EnableObject1()
    {
        if (object1 != null)
            object1.SetActive(true);
    }

    // Function to disable object1
    public void DisableObject1()
    {
        if (object1 != null)
            object1.SetActive(false);
    }

    // Function to enable object2
    public void EnableObject2()
    {
        if (object2 != null)
            object2.SetActive(true);
    }

    // Function to disable object2
    public void DisableObject2()
    {
        if (object2 != null)
            object2.SetActive(false);
    }
}
