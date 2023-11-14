using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class ToolTip : MonoBehaviour
{
    [SerializeField] CanvasGroup panelA;
    [SerializeField] CanvasGroup panelB;
    [SerializeField] TMP_Text titleA;
    [SerializeField] TMP_Text titleB;
    [SerializeField] TMP_Text bodyB;
    [SerializeField] string title;
    [SerializeField] string body;
    [SerializeField] public GameObject tooltip;
    public bool opened;
    public bool firsInteraction;
    countToolTips countToolTips;
    private void Awake()
    {
        countToolTips = FindObjectOfType<countToolTips>();
    }
    private void Start()
    {
        panelB.alpha = 0;
        titleA.text = title;
        titleB.text = title;
        bodyB.text = body;
    }
    public void togglePanel()
    {
        if (opened)
        {
            panelA.DOFade(1, 0.5f).SetDelay(0.2f);
            panelB.DOFade(0, 0.5f);
            opened = false;
        }
        else
        {
            if (!firsInteraction)
            {
                firsInteraction = true;
                countToolTips.AddCount();
            }


            panelA.DOFade(0, 0.5f);
            panelB.DOFade(1, 0.5f).SetDelay(0.1f);
            opened = true;
        }
    }

}
