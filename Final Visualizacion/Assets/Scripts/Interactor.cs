using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;

public class Interactor : MonoBehaviour
{
    public Camera cam;
    private GameObject prevHitObj;
    private Interactable prevInteractable = null;
    private Interactable interactable;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private float rayDist = 10f;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayDist, interactableLayer))
            {
                GameObject hitObj = hit.collider.gameObject;
                interactable = hitObj.GetComponent<Interactable>();
                interactable.Interact(prevInteractable);
                if (prevInteractable != null && prevInteractable != interactable)
                {
                    prevInteractable.StopInteracting();
                }
                prevInteractable = interactable;
            }
            else
            {
                if (prevInteractable != null)
                {
                    prevInteractable.StopInteracting();
                    prevInteractable = null;
                }
                else
                {
                    prevInteractable = null;
                }
            }
        }
    }
}
