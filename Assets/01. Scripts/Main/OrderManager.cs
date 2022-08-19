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
    public string Order { get; private set; } = "";
    public string Submit { get; set; } = "";
    private string[] randList = { "100", "010", "001" };
    private Transform orderPanel = null;
    private Image customerImage = null;
    private TextMeshProUGUI requestTMP = null;
    [SerializeField] private float currentTime = 0;
    private bool onOrdering = false;
    private int getMoney;
    private int getFame;

    private void Awake()
    {
        customerImage = GameObject.Find("Canvas").transform.Find("Customer").GetComponent<Image>();
        orderPanel = GameObject.Find("Canvas").transform.Find("OrderPanel");
        requestTMP = orderPanel.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (JewelryManager.Instance.OnPreparing) return;

        currentTime += Time.deltaTime;

        if (currentTime >= dayTime)
        {
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
            getMoney += Order.Replace("0","").Length * 100;
            getFame += 10;
        }
        else
        {
            getFame -= 10;
        };
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
        getFame -= 5;
    }

    public void MakeOrder()
    {
        GetRandState();
        doPopUp?.Invoke();
        requestTMP.text = DataManager.Instance.Texts[Order];

        for (int i = 0; i < 9; i++)
        {
            JewelryManager.Instance.countTMP[i].text = JewelryManager.Instance.haveJewelry[i].ToString();
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