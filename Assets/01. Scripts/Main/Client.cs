using System.Linq;
using TMPro;
using WebSocketSharp;
using UnityEngine;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Client : MonoBehaviour
{
    public class Packet
    {
        [JsonProperty("n")] public string name;
        [JsonProperty("f")] public int fame;

        public Packet(string _name, int _fame)
        {
            name = _name;
            fame = _fame;
        }
    }

    public static Client Instance = null;

    [SerializeField] string IP, PORT;
    [SerializeField] TextMeshProUGUI nameTMP, fameTMP;
    private WebSocket server;
    private Queue<Action> actions = new Queue<Action>();
    private Dictionary<string, int> leaderBoard = new Dictionary<string, int>();
    private object locker = new object();

    private void Awake()
    {
        server = new WebSocket("ws://" + IP + ":" + PORT);
        server.ConnectAsync();

        server.OnMessage += GetMessages;
    }

    private void GetMessages(object sender, MessageEventArgs args)
    {
        lock(locker)
        {
            Packet p = JsonConvert.DeserializeObject<Packet>(args.Data);
            actions.Enqueue(() => {
                if(leaderBoard.ContainsKey(p.name)) leaderBoard[p.name] = p.fame;
                else leaderBoard.Add(p.name, p.fame);

                ShowLeaderBoard();
            });
        }
    }

    private void Update()
    {
        while(actions.Count > 0) actions.Dequeue()?.Invoke();
    }

    public void SendMessages(string content)
    {
        if(!server.IsAlive) { Debug.Log("Server Not Connected!"); return; }
        server.Send(content);
    }

    public void ShowLeaderBoard()
    {
        leaderBoard = SoltDictionary(leaderBoard);
        nameTMP.text = "";
        fameTMP.text = "";

        foreach(string name in leaderBoard.Keys)
            nameTMP.text += name + " : \n";
        foreach(int fame in leaderBoard.Values)
            fameTMP.text += fame + "\n";
    }

    private Dictionary<string, int> SoltDictionary(Dictionary<string, int> d)
    {
        List<int> temp = d.Values.ToList();
        Dictionary<string, int> dic = new Dictionary<string, int>();
        temp.Sort();
        
        foreach(string s in d.Keys)
        {
            for(int i = 0; i < temp.Count; i++)
                if(d[s] == temp[i])
                {
                    dic.Add(s, temp[i]);
                    break;
                }
        }

        return dic;
    }
}
