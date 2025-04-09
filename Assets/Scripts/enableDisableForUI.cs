using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManagerForUI : MonoBehaviour
{
    [System.Serializable]
    public class ObjectControl
    {
        public GameObject obj;
        public MonoBehaviour[] components;
    }

    public List<ObjectControl> objects;

    public void EnableObject(int index)
    {
        if (index < 0 || index >= objects.Count) return;

        ObjectControl objCtrl = objects[index];
        objCtrl.obj.SetActive(true);
        ToggleComponents(objCtrl, true);
    }

    public void DisableObject(int index)
    {
        if (index < 0 || index >= objects.Count) return;

        ObjectControl objCtrl = objects[index];
        objCtrl.obj.SetActive(false);
        ToggleComponents(objCtrl, false);
    }

    private void ToggleComponents(ObjectControl objCtrl, bool state)
    {
        foreach (var component in objCtrl.components)
        {
            component.enabled = state;
        }
    }
}
