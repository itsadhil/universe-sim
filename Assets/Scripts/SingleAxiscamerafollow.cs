using UnityEngine;

public class CameraFollowSingleAxis : MonoBehaviour
{
    public GameObject[] targets = new GameObject[11]; // Array for 11 GameObjects
    public GameObject cam;
    private Vector3 offset;
    private GameObject currentTarget;
    private int _currentIndex = 0;

    void Start()
    {
        if (targets.Length > 0)
        {
            SetTarget(targets[3]); // Default to first object
        }
    }

    void Update()
    {
        if (currentTarget != null)
        {
            FollowTarget();
        }
    }

    public void SetTarget(GameObject target)
    {
        if (target != null)
        {
            currentTarget = target;
            CalculateOffset();
        }
    }

    public void SetTargetByIndex(int index)
    {
        if (index >= 0 && index < targets.Length)
        {
            _currentIndex = index;
            SetTarget(targets[_currentIndex]);
        }
    }

    public void NextTarget()
    {
        _currentIndex = (_currentIndex + 1) % targets.Length;
        SetTarget(targets[_currentIndex]);
    }

    public void PreviousTarget()
    {
        _currentIndex = (_currentIndex - 1 + targets.Length) % targets.Length;
        SetTarget(targets[_currentIndex]);
    }

    public void SetTarget1() { SetTargetByIndex(0); }
    public void SetTarget2() { SetTargetByIndex(1); }
    public void SetTarget3() { SetTargetByIndex(2); }
    public void SetTarget4() { SetTargetByIndex(3); }
    public void SetTarget5() { SetTargetByIndex(4); }
    public void SetTarget6() { SetTargetByIndex(5); }
    public void SetTarget7() { SetTargetByIndex(6); }
    public void SetTarget8() { SetTargetByIndex(7); }
    public void SetTarget9() { SetTargetByIndex(8); }
    public void SetTarget10() { SetTargetByIndex(9); }
    public void SetTarget11() { SetTargetByIndex(10); }

    private void CalculateOffset()
    {
        if (currentTarget != null)
        {
            Renderer objRenderer = currentTarget.GetComponent<Renderer>();
            if (objRenderer != null)
            {
                float objectSize = objRenderer.bounds.size.magnitude;
                offset = new Vector3(objectSize * 8, objectSize * 5, 0);
            }
            else
            {
                offset = new Vector3(5, 0, 0); // Default offset if no renderer
            }
        }
    }

    private void FollowTarget()
    {
        cam.transform.position = currentTarget.transform.position + offset;
        cam.transform.LookAt(currentTarget.transform);
    }
}