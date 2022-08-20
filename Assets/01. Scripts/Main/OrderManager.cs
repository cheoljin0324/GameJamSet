using System.Runtime.CompilerServices;
using UnityEngine;
using Core;
using UnityEngine.Events;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class OrderManager : MonoSingleton<OrderManager>
{
    [SerializeField] List<Sprite> customers = new List<Sprite>();
    [SerializeField] float dayTime = 600f;
    [SerializeField] UnityEvent doPopUp = null, doPopCustomer, doPopDayClearPanel;
    [SerializeField] private float currentTime = 0;
    private List<Button> jewelries = new List<Button>();
    public string Order { get; private set; } = "";
    public string Submit { get; set; } = "";
    private string[] randList = { "100", "010", "001" };
    private Transform orderPanel = null;
    private Image customerImage = null;
    private TextMeshProUGUI requestTMP = null;
    private bool onOrdering = false;
    public int GetMoney { get; set; }
    public int GetFame { get; set; }
    public int CustomerCount { get; set; }
    public int MakeCount { get; set; }
    private bool dayCleared = false;

    private void Awake()
    {
        customerImage = GameObject.Find("Canvas").transform.Find("Customer").GetComponent<Image>();
        orderPanel = GameObject.Find("Canvas").transform.Find("OrderPanel");
        requestTMP = orderPanel.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        orderPanel.Find("Jewelries").GetComponentsInChildren<Button>(jewelries);
    }

    private void Update()
    {
        if (JewelryManager.Instance.OnPreparing) return;

        currentTime += Time.deltaTime;

        if (currentTime >= dayTime && !dayCleared && !onOrdering)
        {
            dayCleared = true;
            doPopDayClearPanel?.Invoke();
            //데이 클리어 패널 보여주기 데이터 매니저 + getfame , getmoney
        }

        if (!onOrdering && currentTime < dayTime)
        {
            Invoke("GetOrder", 3f);
            onOrdering = true;
        }
    }

    public void CompareOrder()
    {
        if (Order == Submit)
        {
            int money = Order.Replace("0","").Length * 100;
            TextPrefab temp = PoolManager.Instance.Pop("TextPrefab") as TextPrefab;
            temp.SetText($"감사합니다~\n돈 + {money}!!\n명성 + 10!!");
            GetMoney += money;
            MakeCount++;
            GetFame += Order.Replace("0","").Length * 3;
        }
        else
        {
            TextPrefab temp = PoolManager.Instance.Pop("TextPrefab") as TextPrefab;
            temp.SetText($"이게 멉니까!\n명성 - {Order.Replace("0","").Length * 3}!!");
            GetFame -= Order.Replace("0","").Length * 3;
        };
        foreach(Button b in jewelries)
            b.interactable = true;
        onOrdering = false;
    }
    
    private void GetOrder()
    {
        customerImage.sprite = customers[Random.Range(0, customers.Count)];
        doPopCustomer?.Invoke();
        Invoke("MakeOrder", 1.5f);
    }

    public void DiscardOrder()
    {
        onOrdering = false;
        GetFame -= 5;
    }

    public void MakeOrder()
    {
        GetRandState();
        doPopUp?.Invoke();
        requestTMP.text = DataManager.Instance.Texts[Order];

        SetQuantity();
    }

    public void SetQuantity()
    {
        for (int i = 0; i < 9; i++)
        {
            JewelryManager.Instance.countTMP[i].text = "X " + JewelryManager.Instance.haveJewelry[i].ToString();
        }
    }

    private void GetRandState()
    {
        int count = 0;
        Order = "";
        string content = randList[Random.Range(0, 3)];
        for (int i = 0; i < 9; i++)
        {
            if (count >= 3)
            {
                for (int j = 0; j < 9 - i; j++)
                    Order += "000";
                break;
            }
            int temp = Random.Range(0, 3);
            if (temp == 0)
            {
                count++;
                Order += content;
            }
            else Order += "000";
        }
    }

}