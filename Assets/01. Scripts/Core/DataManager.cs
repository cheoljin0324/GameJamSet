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

            string data = File.ReadAllText(path);
            if(data.Length <= 0) userData = new UserData(0, 1, 0, new float[] {5, 5, 5}, 30, "");
            else userData = JsonConvert.DeserializeObject<UserData>(data);

            if(File.Exists(TPath))
                Texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(TPath));
        }
    
        private void OnDisable()
        {
            string JSON = JsonConvert.SerializeObject(userData);
            File.WriteAllText(path, JsonConvert.SerializeObject(JSON));
        }
    }
}
