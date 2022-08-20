using Core;
using UnityEngine;
using TMPro;

public class BagUpgrade : MonoBehaviour
{
    private TextMeshProUGUI cntTMP = null;

    private void Start()
    {
        cntTMP = GetComponentInChildren<TextMeshProUGUI>();
        cntTMP.text = Mathf.FloorToInt((Mathf.Pow(DataManager.Instance.UserData.bag - 30, 2) + 5) * 100) + "원";
    }

    public void Upgrade()
    {
        int cost = Mathf.FloorToInt((Mathf.Pow(DataManager.Instance.UserData.bag - 30, 2) + 5) * 100);
        if(DataManager.Instance.UserData.money < cost)
        {
            TextPrefab temp = PoolManager.Instance.Pop("TextPrefab") as TextPrefab;
            temp.SetText("돈이 부족합니다!!");
            return;
        }
        if(DataManager.Instance.UserData.bag >= 50)
        {
            TextPrefab temp = PoolManager.Instance.Pop("TextPrefab") as TextPrefab;
            temp.SetText("이미 최대레벨입니다!!");
            return;
        }

        DataManager.Instance.UserData.money -= cost;
        DataManager.Instance.UserData.bag++;
        TextPrefab tmp = PoolManager.Instance.Pop("TextPrefab") as TextPrefab;
        tmp.SetText($"업그레이드 성공!!\n돈 - {cost}");
        cntTMP.text = Mathf.FloorToInt((Mathf.Pow(DataManager.Instance.UserData.bag - 30, 2) + 5) * 100) + "원";
    }
}
