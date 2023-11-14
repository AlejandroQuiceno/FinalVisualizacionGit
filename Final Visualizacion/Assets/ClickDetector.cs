using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickDetector : MonoBehaviour
{
    [SerializeField] GameObject gif;
    [SerializeField] GameObject firma;
    AudioSource audioSource;
    CameraToPivotPosition CameraToPivot;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        CameraToPivot = FindObjectOfType<CameraToPivotPosition>();
    }

    public void OnPointerClick()
    {
        Debug.Log("clicked");
        EnableGif();
        CameraToPivot.EnableMovement();
    }

    void EnableGif()
    {
        gif.SetActive(true);
        audioSource.Play();
    }
}
