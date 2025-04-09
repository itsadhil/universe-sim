using UnityEngine;

public class DestroyPlanet : MonoBehaviour
{
    public float collisionThreshold = 0.5f;

    void Update()
    {
        GameObject[] celestials = GameObject.FindGameObjectsWithTag("celestial");

        for (int i = 0; i < celestials.Length; i++)
        {
            for (int j = i + 1; j < celestials.Length; j++)
            {
                GameObject a = celestials[i];
                GameObject b = celestials[j];

                if (!a.activeInHierarchy || !b.activeInHierarchy)
                    continue; // Skip if one is already disabled

                float distance = Vector3.Distance(a.transform.position, b.transform.position);
                float radiusA = a.transform.localScale.magnitude / 2f;
                float radiusB = b.transform.localScale.magnitude / 2f;

                if (distance < (radiusA + radiusB + collisionThreshold))
                {
                    ResolveCollision(a, b);
                }
            }
        }
    }

    void ResolveCollision(GameObject a, GameObject b)
    {
        float scaleA = a.transform.localScale.magnitude;
        float scaleB = b.transform.localScale.magnitude;

        if (scaleA < scaleB)
        {
            a.SetActive(false);
        }
        else if (scaleB < scaleA)
        {
            b.SetActive(false);
        }
        // If they're equal size, you could disable both or leave them.
    }
}