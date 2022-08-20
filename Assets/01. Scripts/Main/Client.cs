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
    private TextMeshProUGUI nameTMP, fameTMP;
    private WebSocket server;
    private Queue<Action> actions = new Queue<Action>();
    private Dictionary<string, int> leaderBoard = new Dictionary<string, int>();
    private object locker = new object();

    private void Awake()
    {
        if(Instance == null) { Instance = this; DontDestroyOnLoad(transform.root.gameObject); }
        else Destroy(transform.root.gameObject);

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
        nameTMP = GameObject.Find("Canvas/MasterPanel/LeaderBoardPanel/Name").GetComponent<TextMeshProUGUI>();
        fameTMP = GameObject.Find("Canvas/MasterPanel/LeaderBoardPanel/Fame").GetComponent<TextMeshProUGUI>();
        leaderBoard = SoltDictionary(leaderBoard);
        nameTMP.text = "";
        fameTMP.text = "";

        int i = 0;
        foreach(string name in leaderBoard.Keys)
        {
            if(i >= 5) break;
            nameTMP.text += name + "\n";
            i++;
        }
        i = 0;
        foreach(int fame in leaderBoard.Values)
        {
            if(i >= 5) break;
            fameTMP.text += "명성도 : " + fame + "\n";
            i++;
        }
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