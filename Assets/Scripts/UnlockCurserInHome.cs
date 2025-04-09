using UnityEngine;

public class UnlockCursor : MonoBehaviour
{
    void Start()
    {
        UnlockCursorLock();
    }

    void UnlockCursorLock()
    {
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible
        
    }
}

