using System.Security.Cryptography.X509Certificates;
using System.Linq;
using UnityEngine;
using Core;

    public class OrderManager : MonoSingleton<OrderManager>
    {
        public string Order { get; private set; } = "";
        public string Submit { get; set; } = "";
        private string[] randList = { "000", "100", "010", "001" };

        private void Start()
        {
            MakeOrder();
        }

        public void CompareOrder()
        {
            if(Order == Submit) Debug.Log("정답");
            else Debug.Log("땡");
        }

        public void MakeOrder()
        {
            int count = 0;
            for(int i = 0; i < 9; i ++)
            {
                string temp = randList[Random.Range(0, 4)];
                Order += temp;
                if(temp != "000")
                {
                    count ++;
                    if(count >= 3)
                    {
                        for(int j = 0; j < 8 - i; j ++)
                            Order += "000";
                        break;
                    }
                }
            }
        }

    }