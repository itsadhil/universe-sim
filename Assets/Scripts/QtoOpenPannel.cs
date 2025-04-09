using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public GameObject targetObject; // Assign the object to be toggled in the Inspector
    public ObjectManager anotherScript; // Reference to another script

    void Start()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false); // Disable on start
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // Check if 'Q' is pressed
        {
            if (targetObject != null)
            {
                targetObject.SetActive(!targetObject.activeSelf); // Toggle active state
            }

            if (anotherScript != null)
            {
                anotherScript.DisableAllObjects(); // Call function from another object
            }
        }

        if (Input.GetKeyDown(KeyCode.E)) // Check if 'E' is pressed
        {
            if (anotherScript != null)
            {
                anotherScript.DisableAllObjects(); // Call another function from another object
            }
        }
    }
}
