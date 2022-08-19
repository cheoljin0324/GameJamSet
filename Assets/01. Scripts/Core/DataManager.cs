using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

namespace Core
{
    [Serializable]
    public class UserData
    {
        [JsonProperty("fame")] public int fame;
        [JsonProperty("day")] public int day;
        [JsonProperty("money")] public int money;

        public UserData(int fame, int day, int money)
        {
            this.fame = fame;
            this.day = day;
            this.money = money;
        }
    }
    public class DataManager : MonoSingleton<DataManager>
    {
        private string path = "Assets/08. JSON/userData.json";
        private string TPath = "Assets/08. JSON/result.json";
        private UserData userData;
        public UserData UserData => userData;
        private Dictionary<string, string> texts;

        private void Awake()
        {
            Initialize();
            if(File.Exists(path))
            {
                userData = JsonConvert.DeserializeObject<UserData>(File.ReadAllText(path));
            }
            else
            {
                userData = new UserData(0, 1, 0);
            }
            if(File.Exists(TPath))
                texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(TPath));

            Debug.Log(texts.Count);

        }
        private void OnApplicationQuit()
        {
            // Fame, Day, Money 가지고 있는 곳에서 세이브하세요.
        }

        public void SaveFile(UserData data)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(data));
        }
    }
}
