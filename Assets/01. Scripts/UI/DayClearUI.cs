using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Core;

public class DayClearUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private GameObject mainReceipt;
    private TextMeshProUGUI[] childTexts;

    private void Awake()
    {
        childTexts = new TextMeshProUGUI[mainReceipt.transform.childCount];
        for(int i = 0; i < mainReceipt.transform.childCount; i++)
        {
            childTexts[i] = mainReceipt.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
        }
    }
    private void OnEnable()
    {
        TextSet();
        Sequence seq = DOTween.Sequence();
        mainReceipt.GetComponent<Image>().DOFade(1f, 0.5f);
        seq.Append(mainReceipt.transform.DOLocalMoveY(-300, 1f));
        foreach(TextMeshProUGUI text in childTexts)
        {
            seq.Append(text.DOFade(1f, 1f).OnPlay(() => text.transform.DOLocalMoveX(10, 0.75f)));
        }
    }

    private void TextSet()
    {
        childTexts[0].text = $"오늘 수익 : {OrderManager.Instance.GetMoney}";
        childTexts[1].text = $"가게 명성 : {20} + {OrderManager.Instance.GetFame}";
        childTexts[2].text = $"다녀간 손님 : {1}명";
    }
}
