using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class FolderEvent : MonoBehaviour
{
    public UnityEvent escPressed;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escPressed?.Invoke();
        }
    }
}
