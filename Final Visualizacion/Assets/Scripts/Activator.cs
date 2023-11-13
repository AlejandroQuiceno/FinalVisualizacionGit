using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Activator : MonoBehaviour
{
    public UnityEvent InvokeOnClick; // UnityEvent to be invoked on click
    public void TriggerEvents()
    {
        // Invoke the UnityEvent named InvokeOnClick
        if (InvokeOnClick != null)
        {
            InvokeOnClick.Invoke();
            Debug.Log("Event called");
        }
    }
}
