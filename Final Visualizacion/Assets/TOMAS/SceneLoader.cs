using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Public variable to set the scene name
    public string sceneToLoad;

    public void LoadStringScene()
    {
        // If a scene name is provided, load that scene
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            // Handle the case where the scene name is not provided
            Debug.LogWarning("Scene name not provided. No scene loaded.");
        }

    }
}
