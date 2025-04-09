using UnityEngine;
using System;
using System.Collections.Generic;

public class ChangeGrav : MonoBehaviour
{
    private readonly Dictionary<string, float> planetGravities = new()
    {
        { "MERCURY", 3.7f },
        { "VENUS", 8.87f },
        { "EARTH", 9.81f },
        { "MARS", 3.71f },
        { "JUPITER", 24.79f },
        { "SATURN", 10.44f },
        { "URANUS", 8.69f },
        { "NEPTUNE", 11.15f },
        { "PLUTO", 0.62f }
    };

    [SerializeField] private float defaultGravity = 9.81f;
    private float lastPlanetGravity;

    void OnEnable()
    {
        ItemGrab.OnPlanetGrabbed += HandlePlanetGrabbed;
    }

    void OnDisable()
    {
        ItemGrab.OnPlanetGrabbed -= HandlePlanetGrabbed;
    }

    private void HandlePlanetGrabbed(GameObject planet)
    {
        if (planet == null) return;

        string planetName = planet.name.ToUpper();
        if (planetGravities.TryGetValue(planetName, out float gravityValue))
        {
            Physics.gravity = Vector3.down * gravityValue;
            lastPlanetGravity = gravityValue;
            Debug.Log($"Gravity set to {gravityValue} for {planetName}");
        }
        else
        {
            Debug.LogWarning($"Unknown planet: {planetName} — using last known gravity: {lastPlanetGravity}");
            Physics.gravity = Vector3.down * lastPlanetGravity;
        }
    }
}
