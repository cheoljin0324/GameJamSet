using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using Core;

public class JewelryManager : MonoSingleton<JewelryManager>
{
    public int[] haveJewelry = new int[9];
    private string[] nameData = { "Metal", "Copper", "Gold", "Coral", "Silver", "MOP", "Pearl", "Lazurite", "Turquoise" };
    public int left = 30;
    private List<Value> values = new List<Value>();
    public List<TextMeshProUGUI> countTMP = new List<TextMeshProUGUI>();

    private void Awake()
    {
        Initialize();

        GameObject.Find("Canvas/SetJewelryPanel/Jewelries").GetComponentsInChildren<Value>(values);
        GameObject obj = GameObject.Find("Canvas/OrderPanel/Jewelries");
        for(int i = 0; i < 9; i++)
        {
            countTMP.Add(obj.transform.GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>());
        }
    }

    public void SetHaveArray(string name, int value)
    {
        haveJewelry[Array.IndexOf(nameData, name)] = value;
    }
    public int GetValue(string name)
    {
        return haveJewelry[Array.IndexOf(nameData, name)];
    }

    public void OpenStore()
    {
        for(int i = 0; i < values.Count; i ++)
        {
            haveJewelry[i] = values[i].foo1;
        }
    }
}