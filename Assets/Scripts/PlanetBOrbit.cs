using UnityEngine;

public class PlanetBOrbit : MonoBehaviour
{
    [Header("Orbit Settings")]
    public Transform planetA;
    public float orbitSpeed = 20f;

    private Vector3 orbitAxis = Vector3.up;

    void Update()
    {
        if (planetA != null)
        {
            transform.RotateAround(planetA.position, orbitAxis, orbitSpeed * Time.deltaTime);
        }
    }
}
