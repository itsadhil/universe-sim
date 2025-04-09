using Unity.XR.CoreUtils;
using UnityEngine;

public class EscapeKeyHandler : MonoBehaviour
{
    public SceneController ScriptA;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEscapePressed();
        }
    }

    void OnEscapePressed()
    {
        Time.timeScale = 1f;
        ScriptA.LoadSceneHome();


    }
}

