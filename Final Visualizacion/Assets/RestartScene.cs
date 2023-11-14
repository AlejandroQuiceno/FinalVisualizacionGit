using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    // Public variable to set the scene name
    public string sceneToLoad;

    void Update()
    {
        // Check if the F key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Restart the specified scene
            RestartSceneByName();
        }
    }

    void RestartSceneByName()
    {
        // Reload the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
