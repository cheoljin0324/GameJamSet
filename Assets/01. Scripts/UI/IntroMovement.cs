using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class IntroMovement : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject settingButton;
    [SerializeField] private GameObject leaderboardBt;
    [SerializeField] private GameObject title;
    private Sequence seq;
    private Sequence titleSeq;

    private void Start()
    {
        Invoke("TitleRoutine", 0.5f);
        ButtonEffect();
    }

    public void TitleRoutine()
    {
        titleSeq = DOTween.Sequence();
        title.GetComponent<TextMeshProUGUI>().DOFade(1, 1f);
        titleSeq.Append(title.transform.DOLocalMoveY(300, 1f).OnComplete(() => {
            settingButton.GetComponent<Image>().DOFade(1f, 0.75f);
            settingButton.GetComponentInChildren<TextMeshProUGUI>().DOFade(1f, 0.75f).OnComplete(() => {
                leaderboardBt.GetComponent<Image>().DOFade(1f, 0.75f);
                leaderboardBt.GetComponentInChildren<TextMeshProUGUI>().DOFade(1f, 0.75f);
            });
        })
        );
    }
    public void ButtonEffect()
    {
        seq = DOTween.Sequence();
        seq.Append(startButton.GetComponentInChildren<TextMeshProUGUI>().DOFade(1f, 1.75f).SetEase(Ease.Linear));
        seq.Append(startButton.GetComponentInChildren<TextMeshProUGUI>().DOFade(0f, 0.5f).SetEase(Ease.Linear));
        seq.SetLoops(-1);
    }

    private void OnDisable()
    {
        seq.Kill();
        titleSeq.Kill();
    }
}