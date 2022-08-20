using TMPro;
using UnityEngine;
using Core;

public class SetMoney : MonoBehaviour
{
    private TextMeshProUGUI tmp = null;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        DoSetText();   
    }

    public void DoSetText()
    {
        tmp.text = DataManager.Instance.UserData.money.ToString();
    }
}
