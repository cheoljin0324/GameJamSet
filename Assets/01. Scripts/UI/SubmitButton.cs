using UnityEngine.Events;
using UnityEngine;
using DG.Tweening;

public class SubmitButton : MonoBehaviour
{
    [SerializeField] RectTransform paperImageRect;
    public UnityEvent submitEvents;
    private Sequence seq;
    private RectTransform rect;
    [SerializeField] Transform[] trms;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public void DoSubmit(float duration)
    {
        seq = DOTween.Sequence();
        seq.Append(rect.DOJump(trms[0].position, 0.5f, 1, duration / 3).SetEase(Ease.InOutCubic));
        seq.Append(rect.DOJump(trms[1].position, 0.5f, 1, duration / 3).SetEase(Ease.InOutCubic));
        seq.Append(rect.DOJump(trms[2].position, 0.5f, 1, duration / 3).SetEase(Ease.InOutCubic));
        seq.Append(rect.DOMove(trms[3].position, duration / 3));
        seq.AppendCallback(() => {
            paperImageRect.gameObject.SetActive(false);
            submitEvents?.Invoke();
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
