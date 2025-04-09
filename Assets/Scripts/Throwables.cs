using UnityEngine;

public class Throwables : MonoBehaviour
{
    public Transform handPosition;
    public float throwForce = 5f;
    public float colliderReenableDelay = 0.5f;

    private GameObject heldItem;
    private Rigidbody heldRb;
    private Collider heldCollider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldItem != null)
                DropObject();
            else
                TryGrabObject();
        }
    }

    private void TryGrabObject()
    {
        Collider[] hits = Physics.OverlapSphere(handPosition.position, 0.2f);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Throwable"))
            {
                heldItem = hit.gameObject;
                heldRb = heldItem.GetComponent<Rigidbody>();
                heldCollider = heldItem.GetComponent<Collider>();

                if (heldCollider != null)
                    heldCollider.enabled = false; // Disable collider on grab

                heldItem.transform.SetParent(handPosition);
                heldItem.transform.localPosition = Vector3.zero;
                heldItem.transform.localRotation = Quaternion.identity;
                heldRb.isKinematic = true;

                break;
            }
        }
    }

    private void DropObject()
    {
        heldItem.transform.SetParent(null);
        heldRb.isKinematic = false;

        // Apply default forward throw force
        heldRb.linearVelocity = Camera.main.transform.forward * throwForce;

        if (heldCollider != null)
            StartCoroutine(ReenableColliderAfterDelay(heldCollider, colliderReenableDelay));

        heldItem = null;
        heldRb = null;
        heldCollider = null;
    }

    private System.Collections.IEnumerator ReenableColliderAfterDelay(Collider collider, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (collider != null)
            collider.enabled = true;
    }
}
