using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;
public class RayOutliner : MonoBehaviour
{
    private Outlinable previousOutlinable;
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        float maxRaycastDistance = 10f;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxRaycastDistance))
        {
            Outlinable currentOutlinable = hit.collider.gameObject.GetComponent<Outlinable>();

            if (currentOutlinable != null)
            {
                currentOutlinable.enabled = true;
                if (previousOutlinable != null && previousOutlinable != currentOutlinable)
                {
                    previousOutlinable.enabled = false;
                }
                previousOutlinable = currentOutlinable;
            }
        }
        else
        {
            if (previousOutlinable != null)
            {
                previousOutlinable.enabled = false;
                previousOutlinable = null;
            }
        }
    }
}
