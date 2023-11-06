using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;
public class RayOutliner : MonoBehaviour
{
    public Camera cam;
    private GameObject prevHitObj;
    private Outlinable prevOutlinable;
    private ToolTip prevTooltip;
    private ToolTip toolTip;

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
        void HitCollider(GameObject hitObj, Outlinable outlinable, ToolTip toolTip)
        {
            if (toolTip != prevTooltip && prevTooltip != null && prevTooltip.opened)
            {
                prevTooltip.togglePanel();
            }
            if (toolTip == prevTooltip)
            {
                toolTip.togglePanel();
            }
            else
            {
                if (outlinable != null && toolTip != null)
                {
                    if (prevOutlinable != outlinable)
                    {
                        if (prevOutlinable != null)
                        {
                            prevTooltip.tooltip.SetActive(false);
                            prevOutlinable.enabled = false;
                        }
                        outlinable.enabled = true;
                        toolTip.tooltip.SetActive(true);
                        prevOutlinable = outlinable;
                        prevTooltip = toolTip;
                    }
                }
                else if (outlinable == null && toolTip != null)
                {
                    if(prevOutlinable != null)
                    {
                        prevTooltip.tooltip.SetActive(false);
                        prevOutlinable.enabled = false;
                        prevTooltip.tooltip.SetActive(false);
                        prevTooltip = null;
                    }
                    else if(prevTooltip != null)
                    {
                        prevTooltip.tooltip.SetActive(false);
                        prevTooltip = null;
                    }
                    toolTip.tooltip.SetActive(true);
                    prevOutlinable = null;
                    prevTooltip = toolTip;
                }
                else
                {
                    if (prevOutlinable != null && prevTooltip != null)
                    {
                        prevTooltip.tooltip.SetActive(false);
                        prevTooltip = null;
                        prevOutlinable.enabled = false;
                        prevOutlinable = null;
                    }
                }
                prevHitObj = hitObj;
            }
        }
    }
}
