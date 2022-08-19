using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace kwak1s1h
{
    public class Test : MonoBehaviour
    {
        private PlayerJewelry playerJewelry;
        private TextMeshProUGUI[] textComps = new TextMeshProUGUI[9];

        private void Awake()
        {
            playerJewelry = GetComponent<PlayerJewelry>();
            for(int i = 0; i < 9; i++)
            {
                textComps[i] = transform.GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>();
            }
        }
        private void Start()
        {
            for(int i = 0; i < 9; i++)
            {
                textComps[i].text = playerJewelry.GetValue(textComps[i].transform.parent.name).ToString();
            }
        }
    }
}