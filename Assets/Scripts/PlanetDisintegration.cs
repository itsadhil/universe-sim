using System.Collections;
using UnityEngine;

public class RocheAnimation : MonoBehaviour
{
    [Header("Debris Settings")]
    public GameObject debrisPrefab;
    public int debrisCount = 10;
    public float minOrbitSpeed = 5f;
    public float maxOrbitSpeed = 15f;

    [Header("Disintegration Settings")]
    public float disintegrationDuration = 5f;
    public float minSpawnInterval = 0.3f;
    public float maxSpawnInterval = 1f;

    [Header("Debris Slowdown Settings")]
    public float finalOrbitSpeed = 3f;  // Final speed after disintegration
    public float slowdownDuration = 3f; // Time taken to reach final speed

    [Header("Planet References")]
    public Transform planetA;
    public float planetBOrbitSpeed = 10f; // Orbit speed of Planet B

    private bool disintegrationStarted = false;
    private float disintegrationStartTime;
    private Vector3 originalScale;
    private DebrisOrbit[] allDebris;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !disintegrationStarted)
        {
            disintegrationStarted = true;
            disintegrationStartTime = Time.time;

            StartCoroutine(SpawnDebris());
            StartCoroutine(ShrinkPlanet());
        }
    }

    private IEnumerator SpawnDebris()
    {
        int halfCount = debrisCount / 2;
        allDebris = new DebrisOrbit[debrisCount];

        for (int i = 0; i < halfCount; i++)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));

            // Spawn debris moving in the direction of the planet
            GameObject debris1 = Instantiate(debrisPrefab, transform.position, Quaternion.identity);
            allDebris[i] = AttachDebrisOrbit(debris1, 1);

            // Spawn debris moving in the opposite direction
            GameObject debris2 = Instantiate(debrisPrefab, transform.position, Quaternion.identity);
            allDebris[i + halfCount] = AttachDebrisOrbit(debris2, -1);
        }
    }

    private IEnumerator ShrinkPlanet()
    {
        float elapsed = 0f;

        while (elapsed < disintegrationDuration)
        {
            float scaleFactor = 1f - (elapsed / disintegrationDuration);
            transform.localScale = originalScale * scaleFactor;

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.zero;

        // Start slowing down debris after disintegration
        StartCoroutine(SlowDownDebris());
    }

    private IEnumerator SlowDownDebris()
    {
        float elapsed = 0f;

        while (elapsed < slowdownDuration)
        {
            float t = elapsed / slowdownDuration;

            foreach (DebrisOrbit debris in allDebris)
            {
                if (debris != null)
                {
                    debris.SetOrbitSpeed(Mathf.Lerp(debris.InitialSpeed, finalOrbitSpeed, t));
                }
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure all debris reach the final speed
        foreach (DebrisOrbit debris in allDebris)
        {
            if (debris != null)
            {
                debris.SetOrbitSpeed(finalOrbitSpeed);
            }
        }
    }

    private DebrisOrbit AttachDebrisOrbit(GameObject debris, int direction)
    {
        DebrisOrbit orbitScript = debris.AddComponent<DebrisOrbit>();
        if (orbitScript != null)
        {
            float randomSpeed = Random.Range(minOrbitSpeed, maxOrbitSpeed);
            if (direction == 1) randomSpeed += planetBOrbitSpeed; // Boost debris moving in planet's direction
            orbitScript.Initialize(planetA, transform.position, randomSpeed * direction);
        }
        return orbitScript;
    }
}
