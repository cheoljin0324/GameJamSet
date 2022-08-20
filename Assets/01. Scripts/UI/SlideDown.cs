using DG.Tweening;
using UnityEngine;

public class SlideDown : MonoBehaviour
{
    [SerializeField] float duration = 1f;
    [SerializeField] RectTransform rect = null;
    private bool isTweening = false;

    public void DoSlideDown()
    {
        if(isTweening) return;

        isTweening = true;
        rect.gameObject.SetActive(true);

        rect.DOLocalMoveY(-1080, duration).OnComplete(() => {
            isTweening = false;
            rect.gameObject.SetActive(false);
            rect.localPosition = Vector3.zero;
        });
    }

    public void DoSlideUp()
    {
        if(isTweening) return;

        isTweening = true;
        rect.localPosition = new Vector3(0, -1080);
        rect.gameObject.SetActive(true);

        rect.DOLocalMoveY(0, duration).OnComplete(() => {
            isTweening = false;
        });
    }
}
