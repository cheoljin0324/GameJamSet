using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

    public class Processor : MonoBehaviour
    {
        private List<Processing> processingList = new List<Processing>();

        private void Awake()
        {
            GetComponentsInChildren<Processing>(processingList);
        }

        public void SetProcessor(int index)
        {
            foreach(Processing p in processingList)
                p.SetIndex(index);
        }

        private void Update()
        {
            if(Input.GetButtonDown("Jump"))
                CompleteOrder();
        }

        public void CompleteOrder()
        {
            foreach(Processing p in processingList)
                for (int i = 0; i < 3; i++)
                    OrderManager.Instance.Submit += p.SendOutState(i);
        }
    }