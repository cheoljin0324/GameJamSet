using System.Diagnostics.Contracts;
using UnityEngine;
using Core;
using UnityEngine.Events;
using TMPro;

public class OrderManager : MonoSingleton<OrderManager>
{
    [SerializeField] UnityEvent doPopUp = null;
    public string Order { get; private set; } = "";
    public string Submit { get; set; } = "";
    private string[] randList = { "000", "100", "010", "001" };
    private GameObject orderPanel = null;
    private TextMeshProUGUI requestTMP = null;

    private void Awake()
    {
        orderPanel = GameObject.Find("Canvas/OrderPanel");
        requestTMP = orderPanel.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public void CompareOrder()
    {
        if (Order == Submit) Debug.Log("정답");
        else Debug.Log("땡");
    }

    public void MakeOrder()
    {
        GetRandState();
        //오브젝트에서 받아오기
        requestTMP.text = ""; //오브젝트에서 받아온 텍스트
    }

    private void GetRandState()
    {
        int count = 0;
        for (int i = 0; i < 9; i++)
        {
            string temp = randList[Random.Range(0, 4)];
            Order += temp;
            if (temp != "000")
            {
                count++;
                if (count >= 3)
                {
                    for (int j = 0; j < 8 - i; j++)
                        Order += "000";
                    break;
                }
            }
        }
    }

}