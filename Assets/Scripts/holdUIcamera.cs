using UnityEngine;

public class RelativeObjectController : MonoBehaviour
{
    public GameObject secondObject; // Assign this in the Inspector
    private Vector3 relativePosition; // Stores the initial relative position
    private bool isVisible = true; // Tracks visibility state

    void Start()
    {
        if (secondObject != null)
        {
            // Store the initial relative position
            relativePosition = secondObject.transform.position - transform.position;
        }
    }

    void Update()
    {
        if (secondObject != null)
        {
            // Maintain the initial relative position
            secondObject.transform.position = transform.position + relativePosition;

            // Toggle visibility with the W key
            if (Input.GetKeyDown(KeyCode.W))
            {
                isVisible = !isVisible;
                secondObject.SetActive(isVisible);
            }
        }
    }
}
