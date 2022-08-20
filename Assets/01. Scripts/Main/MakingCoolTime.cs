using UnityEngine;
using UnityEngine.Events;

public class MakingCoolTime : MonoBehaviour
{
    public UnityEvent doPopDown;
    public UnityEvent<int> doPopUp;

    public void SetCoolTime(float duration)
    {
        Invoke("Invoker", duration);
    }

    private void Invoker()
    {
        doPopDown?.Invoke();
    }
}
