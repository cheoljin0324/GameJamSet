using DG.Tweening;
using UnityEngine;

public class Silde : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] int cellCount;
    [SerializeField] RectTransform rect;

    private bool isTweening = false;

    /// <summary>
    /// rectTrm 슬라이딩
    /// </summary>
    /// <param name="_amount">증가량</param>
    public void DoSlide(float _amount)
    {
        if (isTweening || rect.localPosition.x + _amount < (cellCount - 1) * -1920 || rect.localPosition.x + _amount > 0) return;

        isTweening = true;

        rect.DOLocalMoveX(rect.localPosition.x + _amount, duration).OnComplete(() =>
        {
            isTweening = false;
        });
    }
}
