using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraToPivotPosition : MonoBehaviour
{
    Camera camera;
    [SerializeField] Transform pivot;
    CharacterController character;
    MouseLook mouseLook;
    Transform startTransform;
    private void Awake()
    {
        character = GetComponent<CharacterController>();
        camera = GetComponentInChildren<Camera>();
        mouseLook = GetComponentInChildren<MouseLook>();
    }
    void Start()
    {
        startTransform = camera.transform;
        mouseLook.enabled = false;
        character.enabled = false;
        camera.transform.DOMove(pivot.position, 0);
        camera.transform.DORotate(pivot.transform.eulerAngles, 0);
    }

    public void EnableMovement()
    {
        mouseLook.enabled = true;
        character.enabled = true;
        camera.transform.DOLocalMove(new Vector3(0, 1.36f, 0.59f), 0.2f);
        camera.transform.DORotate(startTransform.transform.eulerAngles, 0.2f);
    }
    public void DisableMovement()
    {
        mouseLook.enabled = false;
        character.enabled = false;
    }
}
