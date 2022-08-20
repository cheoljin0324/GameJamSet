using UnityEngine.Events;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SubmitButton : MonoBehaviour
{
    [SerializeField] RectTransform paperImageRect;
    public UnityEvent submitEvents;
    private Processor processor = null;
    private Sequence seq;
    private RectTransform rect;
    private bool isTweening = false;
    [SerializeField] Transform[] trms;
    [SerializeField] Sprite kanjurSP;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        processor = GameObject.Find("Canvas").transform.Find("ProcessingPanel/ProcessorPanel").GetComponent<Processor>();
    }

    public void DoSubmit(float duration)
    {
        if(isTweening) return;

        isTweening = true;

        seq = DOTween.Sequence();
        seq.Append(rect.DOJump(trms[0].position, 0.5f, 1, duration / 3).SetEase(Ease.InOutCubic));
        seq.Append(rect.DOJump(trms[1].position, 0.5f, 1, duration / 3).SetEase(Ease.InOutCubic));
        seq.Append(rect.DOJump(trms[2].position, 0.5f, 1, duration / 3).SetEase(Ease.InOutCubic));
        seq.Append(rect.DOMove(trms[3].position, duration / 3));
        seq.AppendCallback(() => {
            paperImageRect.DOScale(Vector3.zero, duration / 3).OnComplete(() => {
                paperImageRect.GetComponent<Image>().sprite = kanjurSP;
                paperImageRect.DOScale(Vector3.one, duration / 2).OnComplete(() => {
                    paperImageRect.gameObject.SetActive(false);
                    paperImageRect.GetComponent<Image>().sprite = null;
                    isTweening = false;
                    for(int i = 0; i < processor.processingList.Count; i++)
                        processor.processingList[i].button.interactable = true;
                    submitEvents?.Invoke();
                });
            });
        });
    }

    private void OnDisable()
    {
        seq.Kill();
    }

    public void SetActiveTrue()
    {
        paperImageRect.gameObject.SetActive(true);
    }
}
