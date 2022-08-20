using Core;
using UnityEngine;
using TMPro;

public class DecreaseCoolTime : MonoBehaviour
{
    [SerializeField] int index;
    private TextMeshProUGUI cntTMP = null;

    private void Start()
    {
        cntTMP = GetComponentInChildren<TextMeshProUGUI>();
        cntTMP.text = ((Mathf.Pow(Mathf.FloorToInt((5 - DataManager.Instance.UserData.coolTimes[index]) / 0.5f), 2) + 10 - DataManager.Instance.UserData.coolTimes[index]) * 100) + "원";
    }

    public void Upgrade()
    {
        int level = Mathf.FloorToInt((5 - DataManager.Instance.UserData.coolTimes[index]) / 0.5f);
        float coolTime = DataManager.Instance.UserData.coolTimes[index];
        if(DataManager.Instance.UserData.money < (Mathf.Pow(level, 2) + 10 - coolTime) * 100) 
        {
            TextPrefab temp = PoolManager.Instance.Pop("TextPrefab") as TextPrefab;
            temp.SetText("돈이 부족합니다!!");
            return;
        }
        if(level >= 10)
        {
            TextPrefab temp = PoolManager.Instance.Pop("TextPrefab") as TextPrefab;
            temp.SetText("이미 최대레벨입니다!!");
            return;
        }
        //레벨 공식( 5 - 현재 시간 ) / 0.5
        DataManager.Instance.UserData.money -= Mathf.FloorToInt((Mathf.Pow(level, 2) + 10 - coolTime) * 100); 
        TextPrefab tmp = PoolManager.Instance.Pop("TextPrefab") as TextPrefab;
        tmp.SetText($"업그레이드 성공!!\n돈 - {Mathf.FloorToInt((Mathf.Pow(level, 2) + 10 - coolTime) * 100)}");

        DataManager.Instance.UserData.coolTimes[index] -= 0.5f;

        cntTMP.text = (Mathf.Pow(level, 2) + 10 - coolTime) * 100 + "원";
    }
}