using UnityEngine;
using DG.Tweening;

public class Option : MonoBehaviour
{
    private bool isTweening = false;
    [SerializeField] RectTransform rect;
    [SerializeField] float duration;

    public void DoPopUp()
    {
        if (isTweening) return;

        rect.gameObject.SetActive(true);
        rect.localScale = Vector3.zero;
        isTweening = true;

        rect.DOScale(Vector3.one, duration).OnComplete(() =>
        {
            isTweening = false;
            Time.timeScale = 0;
        });
    }

    public void DoPopDown()
    {
        if (isTweening) return;

        Time.timeScale = 1;
        isTweening = true;
        rect.DOScale(Vector3.zero, duration).OnComplete(() =>
        {
            isTweening = false;
            rect.gameObject.SetActive(false);
        });
    }
}
