using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IdleIcon : MonoBehaviour
{
    float initialY;
    [SerializeField] float offset;
    private void Awake()
    {
        initialY = transform.position.y;
        offset += initialY;
    }
    private void Start()
    {   
            transform.DOMoveY(initialY+0.1f, 1f)
        .SetLoops(-1, LoopType.Yoyo)
        .SetEase(Ease.InOutSine);
    }
}
