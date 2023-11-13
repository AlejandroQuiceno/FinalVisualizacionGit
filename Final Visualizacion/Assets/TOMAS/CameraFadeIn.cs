using UnityEngine;

public class CameraFadeIn : MonoBehaviour
{
    public float fadeDuration = 2f; // Time in seconds for the fade-in effect
    private Camera mainCamera;
    private Color initialClearColor;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        initialClearColor = mainCamera.backgroundColor;

        // Set the camera clear color to black initially
        mainCamera.clearFlags = CameraClearFlags.SolidColor;
        mainCamera.backgroundColor = Color.black;

        // Start the fade-in effect
        StartCoroutine(FadeIn());
    }

    private System.Collections.IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // Calculate the lerp factor
            float t = elapsedTime / fadeDuration;

            // Lerp the camera clear color from black to the initial color
            mainCamera.backgroundColor = Color.Lerp(Color.black, initialClearColor, t);

            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Ensure the final clear color is the initial color
        mainCamera.backgroundColor = initialClearColor;

        // Set the camera clear flags to the original value
        mainCamera.clearFlags = CameraClearFlags.Skybox; // or Depth or any other option based on your scene requirements
    }
}
