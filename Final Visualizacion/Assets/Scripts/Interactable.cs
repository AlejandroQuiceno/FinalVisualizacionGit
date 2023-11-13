using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;
public class Interactable : MonoBehaviour
{
    [SerializeField] ToolTip toolTip;
    [SerializeField] Outlinable outlinable;
    private void Awake()
    {
        TryGetComponent<ToolTip>(out toolTip);
        TryGetComponent<Outlinable>(out outlinable);
    }
    public void Select(Interactable preInteractable)
    {
        if(toolTip != null)
        {
            toolTip.tooltip.SetActive(true);
            if(preInteractable == this)
            {
                toolTip.togglePanel();
            }
        }
        if(outlinable != null)
        {
            outlinable.enabled = true;
        }
    }
    public void DesSelect()
    {
        if (toolTip != null)
        {
            toolTip.tooltip.SetActive(false);
            if (toolTip.opened)
            {
                toolTip.togglePanel();
            }
        }
        if (outlinable != null)
        {
            outlinable.enabled = false;
        }
    }
}
