using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class UserData
    {
        [JsonProperty("name")] public string name;
        [JsonProperty("fame")] public int fame;
        [JsonProperty("day")] public int day;
        [JsonProperty("money")] public int money;
        [JsonProperty("coolTimes")] public float[] coolTimes;
        [JsonProperty("bag")] public int bag;

        public UserData(string name, int fame, int day, int money, float[] coolTimes, int bag)
        {
            this.name = name;
            this.fame = fame;
            this.day = day;
            this.money = money;
            this.coolTimes = coolTimes;
            this.bag = bag;
        }
    }

    public class DataManager : MonoBehaviour
    {
        public static DataManager Instance = null;

        [SerializeField] TextAsset texts;
        [SerializeField] UserData userData;
        public UserData UserData => userData;
        public Dictionary<string, string> Texts;

        public void Awake()
        {
            if(Instance == null) { Instance = this; DontDestroyOnLoad(transform.root.gameObject); }
            else { Destroy(transform.root.gameObject); }

            string data = PlayerPrefs.GetString("UserData", "");
            Debug.Log(data);
            if(data.Length <= 0 || data == null || data == "null") userData = new UserData("", 0, 1, 0, new float[] {5, 5, 5}, 30);
            else userData = JsonConvert.DeserializeObject<UserData>(data);

            string textData = texts.text;
            if(textData.Length <= 0) return;
                Texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(textData);
        }

        private void OnDisable()
        {
            SaveFile();
        }

        private void OnDestroy()
        {
            SaveFile();
        }

        private void OnApplicationQuit()
        {
            SaveFile();   
        }
        public void SaveFile()
        {
            string JSON = JsonConvert.SerializeObject(userData);
            PlayerPrefs.SetString("UserData", JSON);
            PlayerPrefs.Save();
        }
    }
}
