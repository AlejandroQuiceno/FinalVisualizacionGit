using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;
public class RayOutliner : MonoBehaviour
{
    private Camera cam;
    private GameObject prevHitObj;
    private Outlinable prevOutlinable;

    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private float rayDist = 10f;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDist, interactableLayer))
        {
            GameObject hitObj = hit.collider.gameObject;
            Outlinable outlinable = hitObj.GetComponent<Outlinable>();

            if (outlinable != null)
            {
                if (prevOutlinable != outlinable)
                {
                    if (prevOutlinable != null)
                    {
                        prevOutlinable.enabled = false;
                    }
                    outlinable.enabled = true;
                    prevOutlinable = outlinable;
                }
            }
            else
            {
                if (prevOutlinable != null)
                {
                    prevOutlinable.enabled = false;
                    prevOutlinable = null;
                }
            }
            prevHitObj = hitObj;
        }
        else
        {
            if (prevOutlinable != null)
            {
                prevOutlinable.enabled = false;
                prevOutlinable = null;
            }
        }
    }
}
