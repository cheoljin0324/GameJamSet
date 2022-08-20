using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Core
{
    public class UserData
    {
        [JsonProperty("name")] public string name;
        [JsonProperty("fame")] public int fame;
        [JsonProperty("day")] public int day;
        [JsonProperty("money")] public int money;
        [JsonProperty("coolTimes")] public float[] coolTimes;
        [JsonProperty("bag")] public int bag;

        public UserData(int fame, int day, int money, float[] coolTimes, int bag, string name)
        {
            this.fame = fame;
            this.day = day;
            this.money = money;
            this.coolTimes = coolTimes;
            this.bag = bag;
            this.name = name;
        }
    }

    public class DataManager : MonoBehaviour
    {
        public static DataManager Instance = null;

        private string path = "Assets/08. JSON/userData.json";
        private string TPath = "Assets/08. JSON/result.json";
        private UserData userData;
        public UserData UserData => userData;
        public Dictionary<string, string> Texts;

        private void Awake()
        {
            if(Instance == null) { Instance = this; DontDestroyOnLoad(transform.root.gameObject); }
            else { Destroy(transform.root.gameObject); }

            if(File.Exists(path))
            {
                userData = JsonConvert.DeserializeObject<UserData>(File.ReadAllText(path));
            }
            else
            {
                userData = new UserData(0, 1, 0, new float[] {1, 1, 1}, 30, "");
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
