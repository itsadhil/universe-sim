using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadSceneHome()
    {
        SceneManager.LoadScene("PChomeScreenUI");
    }

    public void LoadSceneSolatsystem()
    {
        SceneManager.LoadScene("solarSystem");
    }

    public void LoadSceneThreeBodyProbelem()
    {
        SceneManager.LoadScene("PCthreeBodyProblem");
    }

    public void LoadSceneRochee()
    {
        SceneManager.LoadScene("PCriochee");
    }

    public void LoadSceneSandBox()
    {
        SceneManager.LoadScene("planetssurface");
    }

    public void LoadSceneMusium()
    {
        SceneManager.LoadScene("PCmusium");
    }
}
