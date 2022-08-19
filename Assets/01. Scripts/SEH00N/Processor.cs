using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

namespace SEH00N
{
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
                p.Index = index;
        }
    }
}
