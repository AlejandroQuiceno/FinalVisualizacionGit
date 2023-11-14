using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBillboard : MonoBehaviour
{
    public Transform target;
    
    private void Awake()
    {
        target = FindObjectOfType<Camera>().transform;
    }
    void Update()
    {
        transform.LookAt(target, Vector3.up);
    }
}
