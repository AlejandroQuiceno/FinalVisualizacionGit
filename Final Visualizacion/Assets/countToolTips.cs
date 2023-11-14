using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class countToolTips : MonoBehaviour
{
    [SerializeField] private int count;
    public UnityEvent OnInteraction;
    public void AddCount()
    {
        count++;
        if(count == 7)
        {
            OnInteraction?.Invoke();
        }
    }
}
