using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;
public class RayOutliner : MonoBehaviour
{
    public Camera cam;
    private GameObject prevHitObj;
    private Interactable prevInteractable;
    private Interactable interactable;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private float rayDist = 10f;

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
                interactable.Select(prevInteractable);  
                if (prevInteractable != null && prevInteractable != interactable)
                {
                    prevInteractable.DesSelect();
                }
                prevInteractable = interactable;
            }
            else
            {
                if(prevInteractable != null)
                {
                    prevInteractable.DesSelect();
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
