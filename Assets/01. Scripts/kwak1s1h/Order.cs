using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kwak1s1h
{
    public class Order : MonoBehaviour
    {
        private void Start()
        {
            GetRandVal();
        }
        public int[] GetRandVal()
        {
            int[] result = new int[28];
            for(int i = 0; i < result.Length - 1; i++)
            {
                result[i] = Random.Range(0, 2);
            }
            result[result.Length - 1] = Random.Range(0, 6);
            string temp = "";
            foreach(int num in result)
            {
                temp += num;
            }
            Debug.Log(temp);
            return result;
        }
    }
}