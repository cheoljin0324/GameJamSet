using Core;
using UnityEngine;

public class DecreaseCoolTime : MonoBehaviour
{
    public void Upgrade(int index)
    {
        if(DataManager.Instance.UserData.money < DataManager.Instance.UserData.coolTimes[index]) 
        {
            TextPrefab temp = PoolManager.Instance.Pop("TextPrefab") as TextPrefab;
            temp.SetText("돈이 부족해요!!");
            return;
        }
        if(/*레벨 계산*/false)
        {
            TextPrefab temp = PoolManager.Instance.Pop("TextPrefab") as TextPrefab;
            temp.SetText("이미 최대레벨입니다!!");
            return;
        }
        // level++;
        // DataManager.Instance.UserData.money -= level * level ; //임의 연산 추가 필요
        // DataManager.Instance.UserData.coolTimes[index] -= 0.5f;
        // PlayerPrefs.SetInt("cool" + index, level);
    }
}