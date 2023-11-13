using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntereractBehaviour : MonoBehaviour
{
    private void Update()
    {
        /*
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDist, interactableLayer))
            {
                GameObject hitObj = hit.collider.gameObject;
                hitObj.TryGetComponent(out Outlinable outlinable);
                toolTip = hitObj.GetComponent<ToolTip>();
                HitCollider(hitObj, outlinable, toolTip);
            }
            else
            {
                if (prevOutlinable != null && prevTooltip != null)
                {
                    if (prevTooltip.opened)
                    {
                        prevTooltip.togglePanel();
                    }
                    prevTooltip.tooltip.SetActive(false);
                    prevTooltip = null;
                    prevOutlinable.enabled = false;
                    prevOutlinable = null;
                }
            }
        }
        */
    }
}
