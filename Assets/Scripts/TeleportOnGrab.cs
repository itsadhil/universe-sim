using UnityEngine;

public class PlanetTeleport : MonoBehaviour
{
    [Header("Assign your player prefab root (includes camera)")]
    public Transform playerPrefab;

    [Header("Set target placeholders")]
    public Transform venusPlaceholder;
    public Transform marsPlaceholder;
    public Transform mercuryPlaceholder;
    public Transform defaultPlaceholder;

    private void OnEnable()
    {
        ItemGrab.OnPlanetGrabbed += HandlePlanetGrabbed;
    }

    private void OnDisable()
    {
        ItemGrab.OnPlanetGrabbed -= HandlePlanetGrabbed;
    }

    private void HandlePlanetGrabbed(GameObject planet)
    {
        string name = planet.name.ToUpper();

        if (name == "VENUS" && venusPlaceholder != null)
            playerPrefab.position = venusPlaceholder.position;
        else if (name == "MARS" && marsPlaceholder != null)
            playerPrefab.position = marsPlaceholder.position;
        else if (name == "MERCURY" && mercuryPlaceholder != null)
            playerPrefab.position = mercuryPlaceholder.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (defaultPlaceholder != null && playerPrefab != null)
                playerPrefab.position = defaultPlaceholder.position;
        }
    }
}
