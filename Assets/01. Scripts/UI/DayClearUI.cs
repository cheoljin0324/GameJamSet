using Newtonsoft.Json;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Core;

public class DayClearUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private GameObject dataObject;
    private TextMeshProUGUI[] texts;
    private TextMeshProUGUI[] dataTexts;
    private UserData ud;
    private void Awake()
    {
        ud = DataManager.Instance.UserData;
        dataTexts = new TextMeshProUGUI[4];
        for(int i = 0; i < dataTexts.Length; i++)
        {
            dataTexts[i] = dataObject.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
        }
        texts = new TextMeshProUGUI[4];
        for(int i = 0; i < texts.Length; i++)
        {
            texts[i] = transform.GetChild(i).GetComponent<TextMeshProUGUI>();
        }
    }
    private void OnEnable()
    {
        ud = DataManager.Instance.UserData;
        TextSet();
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOLocalMoveY(-100, 2f));
        seq.Append(dayText.DOFade(1f, 0.75f));
        foreach(TextMeshProUGUI text in texts)
        {
            seq.Append(text.DOFade(1f, 0.75f).OnStart(() => {text.transform.DOLocalMoveX(-250, 0.75f);}));
        }
    }

    private void TextSet()
    {
        dayText.text = $"{ud.day}일 째";
        dataTexts[0].text = $"+{OrderManager.Instance.GetMoney}$";
        dataTexts[1].text = $"{OrderManager.Instance.CustomerCount}명";
        dataTexts[2].text = $"{OrderManager.Instance.MakeCount}개";
        dataTexts[3].text = OrderManager.Instance.GetFame > 0 ? $"+{OrderManager.Instance.GetFame}" : $"{OrderManager.Instance.GetFame}";

        ud.day++;
        ud.fame += OrderManager.Instance.GetFame;
        ud.money += OrderManager.Instance.GetMoney;
        OrderManager.Instance.GetFame = 0;
        OrderManager.Instance.GetMoney = 0;
        OrderManager.Instance.MakeCount = 0;
        OrderManager.Instance.CustomerCount = 0;
        OrderManager.Instance.CurrentTime = 0;

        string JSON = JsonConvert.SerializeObject(new Client.Packet(ud.name, ud.fame));
        Client.Instance.SendMessages(JSON);
    }
    public void ResetPos()
    {
        foreach(var text in texts)
        {
            text.transform.localPosition -= new Vector3(100, 0);
        }
        OrderManager.Instance.dayCleared = false;
        transform.localPosition += new Vector3(100, 0);
    }
}