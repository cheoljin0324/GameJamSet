using UnityEngine;
using Core;

public class UIManager : MonoSingleton<UIManager>
{
    public GameObject NoticeCanvas { get; private set; } = null;

    private void Awake()
    {
        Initialize(true);
    }
}
