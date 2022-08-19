using System.Diagnostics.Contracts;
using UnityEngine;
using Core;
using UnityEngine.Events;
using TMPro;
using System.Collections.Generic;

public class OrderManager : MonoSingleton<OrderManager>
{
    [SerializeField] List<Sprite> customers = new List<Sprite>();
    [SerializeField] float dayTime = 600f;
    [SerializeField] UnityEvent doPopUp = null;
    public string Order { get; private set; } = "";
    public string Submit { get; set; } = "";
    private string[] randList = { "000", "100", "010", "001" };
    private Transform orderPanel = null;
    private TextMeshProUGUI requestTMP = null;
    private float currentTime = 0;
    private bool onOrdering = false;
    private int getMoney;
    private int getFame;

    private void Awake()
    {
        orderPanel = GameObject.Find("Canvas").transform.GetChild(1);
        requestTMP = orderPanel.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if(JewelryManager.Instance.OnPreparing) return;

        currentTime += Time.deltaTime;

        if(currentTime >= dayTime)
        {
            //데이 클리어 패널 보여주기 데이터 매니저 + getfame , getmoney
        }

        if(!onOrdering && currentTime < dayTime)
        {
            Invoke("MakeOrder", 3f);
            onOrdering = true;
        }
    }

    public void CompareOrder()
    {
        if (Order == Submit) 
        {
            getMoney += 1000;
            getFame += 10;
        }
        else
        {
            getFame -= 10;
        };

        onOrdering = false;
    }

    public void MakeOrder()
    {
        GetRandState();
        doPopUp?.Invoke();
        //오브젝트에서 받아오기
        requestTMP.text = ""; //오브젝트에서 받아온 텍스트

        for(int i = 0; i < 9; i ++)
        {
            JewelryManager.Instance.countTMP[i].text = JewelryManager.Instance.haveJewelry[i].ToString();
        }
    }

    private void GetRandState()
    {
        int count = 0;
        string content = randList[Random.Range(1, 4)];
        for (int i = 0; i < 9; i++)
        {
            int temp = Random.Range(0, 3);
            if(temp == 0)
            {
                count ++;
                Order += content;
            }
            else Order += "000";
        
            if (count >= 3)
            {
                for (int j = 0; j < 8 - i; j++)
                    Order += "000";
                break;
            }
        }
    }

}