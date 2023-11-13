using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;
public class Interactable : MonoBehaviour
{
    [SerializeField] ToolTip toolTip;
    [SerializeField] Activator activator;
    private void Awake()
    { 
        if(toolTip == null)
        {
            TryGetComponent<ToolTip>(out toolTip);
        }
        if(activator == null)
        {
            TryGetComponent<Activator>(out activator);
        }
    }
    public void Interact(Interactable prevInteractable)
    {
        if(toolTip != null)
        {
            toolTip.tooltip.SetActive(true);
            if(prevInteractable == this)
            {
                toolTip.togglePanel();
            }
        }
        if (activator != null)
        {
            activator.TriggerEvents();
        }
    }
    public void StopInteracting()
    {
        if (toolTip != null)
        {
            toolTip.tooltip.SetActive(false);
            if (toolTip.opened)
            {
                toolTip.togglePanel();
            }
        }
    }
}
