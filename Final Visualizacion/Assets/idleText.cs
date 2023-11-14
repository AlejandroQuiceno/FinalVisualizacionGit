using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class idleText : MonoBehaviour
{
    [SerializeField] float fadeDuration;
    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void Start()
    {
            image.DOFade(0, fadeDuration)
        .SetEase(Ease.Linear)
        .OnComplete(() => image.DOFade(0, fadeDuration)
        .SetEase(Ease.Linear)
        .SetDelay(1f))
        .SetLoops(-1, LoopType.Yoyo);
    }
}
