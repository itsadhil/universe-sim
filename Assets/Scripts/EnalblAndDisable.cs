using UnityEngine;
using System.Collections;

public class DisableObjects : MonoBehaviour
{
    public GameObject[] objectsToDisable; // Assign objects in the Inspector

    void Start()
    {
        StartCoroutine(DisableAllObjectsWithDelay());
    }

    IEnumerator DisableAllObjectsWithDelay()
    {
        yield return new WaitForSeconds(3f);
        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }

    public void EnableAllObjects()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
