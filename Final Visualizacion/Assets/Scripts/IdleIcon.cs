using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IdleIcon : MonoBehaviour
{
    float initialY;
    [SerializeField] float offset;
    [SerializeField] float AnimationTime;
    private void Awake()
    {
        initialY = transform.localPosition.y;
    }
    private void Start()
    {   
         transform.DOLocalMoveY(initialY- offset, AnimationTime)
        .SetLoops(-1, LoopType.Yoyo)
        .SetEase(Ease.InOutSine);
    }
}
