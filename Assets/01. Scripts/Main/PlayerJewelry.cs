using System;
using UnityEngine;

    public class PlayerJewelry : MonoBehaviour
    {
        [SerializeField] private int[] haveJewelry = new int[9];
        private string[] nameData = { "Metal", "Copper", "Gold", "Coral", "Silver", "MOP", "Pearl", "Lazurite", "Turquoise" };

        public void SetHaveArray(string name, int value)
        {
            haveJewelry[Array.IndexOf(nameData, name)] = value;
        }
        public int GetValue(string name)
        {
            return haveJewelry[Array.IndexOf(nameData, name)];
        }
    }
