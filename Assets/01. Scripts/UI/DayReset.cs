using UnityEngine.Events;
using UnityEngine;

public class DayReset : MonoBehaviour
{
    [SerializeField] GameObject dayClearPanel;
    [SerializeField] RectTransform rect, jewelryPanel;
    [SerializeField] UnityEvent doSlideUp;

    public void DayAfter()
    {
        doSlideUp?.Invoke();
        rect.localPosition = new Vector3(0, -2000);
        jewelryPanel.localPosition = new Vector3(0, 0);
        OrderManager.Instance.dayCleared = false;
        OrderManager.Instance.CurrentTime = 0;
        dayClearPanel.SetActive(false);
    }
}
