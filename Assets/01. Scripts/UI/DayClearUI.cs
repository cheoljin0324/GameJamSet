using Newtonsoft.Json;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Core;

public class DayClearUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private GameObject mainReceipt;
    private TextMeshProUGUI[] childTexts;
    private UserData ud = null;

    private void Awake()
    {
        childTexts = new TextMeshProUGUI[mainReceipt.transform.childCount];
        for(int i = 0; i < mainReceipt.transform.childCount; i++)
        {
            childTexts[i] = mainReceipt.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
        }
    }
    private void OnEnable()
    {
        ud = DataManager.Instance.UserData;
        TextSet();
        Sequence seq = DOTween.Sequence();
        mainReceipt.GetComponent<Image>().DOFade(1f, 0.5f);
        seq.Append(mainReceipt.transform.DOLocalMoveY(-300, 1f));
        foreach(TextMeshProUGUI text in childTexts)
        {
            seq.Append(text.DOFade(1f, 1f).OnPlay(() => text.transform.DOLocalMoveX(10, 0.75f)));
        }
    }

    private void TextSet()
    {
        childTexts[0].text = $"오늘 수익 : {OrderManager.Instance.GetMoney}";
        childTexts[1].text = $"가게 명성 : {DataManager.Instance.UserData.fame} + {OrderManager.Instance.GetFame}";
        childTexts[2].text = $"다녀간 손님 : {OrderManager.Instance.CustomerCount}명";

        ud.day++;
        ud.fame += OrderManager.Instance.GetFame;
        ud.money += OrderManager.Instance.GetMoney;
        OrderManager.Instance.GetFame = 0;
        OrderManager.Instance.GetMoney = 0;

        string JSON = JsonConvert.SerializeObject(new Client.Packet(ud.name, ud.fame));
        Client.Instance.SendMessages(JSON);
    }
}