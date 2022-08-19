using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace Core
{
    public class UserData
    {
        [JsonProperty("fame")] public int fame;
        [JsonProperty("day")] public int day;
        [JsonProperty("money")] public int money;
        [JsonProperty("coolTimes")] public float[] coolTimes;

        public UserData(int fame, int day, int money, float[] coolTimes)
        {
            this.fame = fame;
            this.day = day;
            this.money = money;
            this.coolTimes = coolTimes;
        }
    }
    public class DataManager : MonoSingleton<DataManager>
    {
        private string path = "Assets/08. JSON/userData.json";
        private string TPath = "Assets/08. JSON/result.json";
        private UserData userData;
        public UserData UserData => userData;
        public Dictionary<string, string> Texts;

        private void Awake()
        {
            Initialize();
            if(File.Exists(path))
            {
                userData = JsonConvert.DeserializeObject<UserData>(File.ReadAllText(path));
            }
            else
            {
                userData = new UserData(0, 1, 0, new float[] {1, 1, 1});
            }
            if(File.Exists(TPath))
                Texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(TPath));
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
