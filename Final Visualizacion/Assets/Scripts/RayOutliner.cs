using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;
public class RayOutliner : MonoBehaviour
{
    private Camera cam;
    private GameObject prevHitObj;
    private Outlinable prevOutlinable;
    private ToolTip prevTooltip;
    private ToolTip toolTip;

    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private float rayDist = 10f;

    void Start()
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
                Outlinable outlinable = hitObj.GetComponent<Outlinable>();
                toolTip = hitObj.GetComponent<ToolTip>();
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
                    prevHitObj = hitObj;
                }
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
    }
}
