using Core;
using UnityEngine;
using UnityEngine.UI;

public class Processing : MonoBehaviour
{
    [SerializeField] int count;
    private int[] state = { 0, 0, 0 };
    private Button button = null;
    private MakingCoolTime ctime = null;
    public int Index { get; set; } = 0;

    private void Awake()
    {
        ctime = transform.parent.GetComponent<MakingCoolTime>();
        button = GetComponent<Button>();
    }

    public void DoProcessing()
    {
        if(JewelryManager.Instance.haveJewelry[count] <= 0)
        {
            TextPrefab temp = PoolManager.Instance.Pop("TextPrefab") as TextPrefab;
            temp.SetText("보석이 부족해요!!");
            return;
        }

        ctime.doPopUp?.Invoke();
        ctime.SetCoolTime(DataManager.Instance.UserData.coolTimes[Index]);
        JewelryManager.Instance.haveJewelry[count]--;
        state[Index]++;
        button.interactable = false;
    }

    public int SendOutState(int index)
    {
        return state[index];
    }
}