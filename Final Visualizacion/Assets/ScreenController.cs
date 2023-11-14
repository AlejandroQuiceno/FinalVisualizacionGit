using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScreenController : MonoBehaviour
{
    bool anyKeyPressed;
    [SerializeField] CanvasGroup[] canvasGroups;
    ContractWriter contractWriter;
    private void Awake()
    {
        contractWriter = FindObjectOfType<ContractWriter>();
    }
    void Start()
    {
        StartCoroutine(ScreenCourrutine());
    }
    void Update()
    {
        if(Input.anyKeyDown || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            anyKeyPressed = true;
        }
    }
    IEnumerator ScreenCourrutine()
    {
        FadeIn(0, 0);
        yield return new WaitUntil(() => anyKeyPressed == true);
        FadeOut(0, 0);
        FadeIn(1, 0);
        contractWriter.StartWriting();
    }
    private void FadeOut(int i, float delay)
    {
        canvasGroups[i].DOFade(0, 0.5f).SetEase(Ease.InOutSine).SetDelay(delay);
    }
    private void FadeIn(int i,float delay)
    {
        canvasGroups[i].DOFade(1, 0.5f).SetEase(Ease.InOutSine).SetDelay(delay);
    }
}
