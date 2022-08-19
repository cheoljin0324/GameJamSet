using DG.Tweening;
using UnityEngine;

namespace SEH00N
{
    public class PopUp : MonoBehaviour
    {
        [SerializeField] float duration = 1f;
        [SerializeField] RectTransform rect = null;
        private bool isTweening = false;

        /// <summary>
        /// rectTrm 패널 팝 업
        /// </summary>
        public void DoPopUp()
        {
            if(isTweening) return;

            rect.gameObject.SetActive(true);
            rect.localScale = Vector3.zero;
            isTweening = true;

            rect.DOScale(Vector3.one, duration).OnComplete(() => {
                isTweening = false;
            });
        }

        /// <summary>
        /// rectTrm 패널 팝 다운
        /// </summary>
        public void DoPopDown()
        {
            if(isTweening) return;

            isTweening = true;
            rect.DOScale(Vector3.zero, duration).OnComplete(() => {
                isTweening = false;
                rect.gameObject.SetActive(false);
            });
        }
    }
}
