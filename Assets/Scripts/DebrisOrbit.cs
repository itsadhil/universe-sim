using UnityEngine;

public class DebrisOrbit : MonoBehaviour
{
    private Transform planetA;
    private Vector3 orbitAxis;
    private float orbitSpeed;
    public float InitialSpeed { get; private set; } // Store initial speed

    public void Initialize(Transform centralPlanet, Vector3 startPosition, float speed)
    {
        planetA = centralPlanet;
        orbitAxis = Vector3.up;
        orbitSpeed = speed;
        InitialSpeed = speed; // Store for slowdown calculation
    }

    void Update()
    {
        if (planetA != null)
        {
            transform.RotateAround(planetA.position, orbitAxis, orbitSpeed * Time.deltaTime);
        }
    }

    public void SetOrbitSpeed(float newSpeed)
    {
        orbitSpeed = newSpeed;
    }
}
