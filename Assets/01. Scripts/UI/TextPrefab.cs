using Core;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TextPrefab : PoolableMono
{
    [SerializeField] Vector2 spawnPos = new Vector2();
    [SerializeField] float duration = 10f, distance = 270f;
    private TextMeshProUGUI tmp = null;
    private Sequence seq = null;
    private Transform canvas = null;

    private void Awake()
    {
        canvas = GameObject.Find("NoticeCanvas").transform;
        tmp = GetComponent<TextMeshProUGUI>();
    }

    public override void Reset()
    {
        tmp.alpha = 1;
        transform.SetParent(canvas);
        transform.localPosition = spawnPos;
        transform.localScale = Vector3.one;

        FadeOut();
    }

    public void SetText(string content)
    {
        tmp.text = content;
    }

    private void FadeOut()
    {
        seq = DOTween.Sequence();
        seq.Append(tmp.DOFade(0, duration));
        seq.Join(transform.DOLocalMoveY(spawnPos.y + distance, duration));
        seq.AppendCallback(() => {
            PoolManager.Instance.Push(this);
        });
    }

    private void OnDisable()
    {
        seq.Kill();    
    }
}
