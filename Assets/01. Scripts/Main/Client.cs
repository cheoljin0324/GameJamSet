using System.Reflection;
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
    private Queue<Action> leaderBoardReq = new Queue<Action>();
    private Dictionary<string, int> leaderBoard = new Dictionary<string, int>();
    private object locker = new object();
    public bool IsReq { get; set; }

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
            if (args.Data == "res")
            {
                actions.Enqueue(() => {
                    ShowLeaderBoard();
                });
                return;
            }
            Packet p = JsonConvert.DeserializeObject<Packet>(args.Data);

            actions.Enqueue(() => {
                if(leaderBoard.ContainsKey(p.name)) leaderBoard[p.name] = p.fame;
                else leaderBoard.Add(p.name, p.fame);
            });
        }
    }

    private void Update()
    {
        while(actions.Count > 0) actions.Dequeue()?.Invoke();
    }

    private void LateUpdate()
    {
        while(leaderBoardReq.Count > 0) leaderBoardReq.Dequeue()?.Invoke();
    }

    public void SendMessages(string content)
    {
        if(!server.IsAlive) { Debug.Log("Server Not Connected!"); return; }
        server.Send(content);
    }

    public void ShowLeaderBoard()
    {
        if (!GameObject.Find("Canvas/MasterPanel/LeaderBoardPanel/Name").TryGetComponent<TextMeshProUGUI>(out nameTMP) ||
        !GameObject.Find("Canvas/MasterPanel/LeaderBoardPanel/Fame").TryGetComponent<TextMeshProUGUI>(out fameTMP))
            return;
        leaderBoard = SoltDictionary(leaderBoard);
        nameTMP.text = "";
        fameTMP.text = "";

        int i = 0;
        foreach (string name in leaderBoard.Keys)
        {
            if (i >= 6) break;
            nameTMP.text += name + "\n";
            i++;
        }
        i = 0;
        foreach (int fame in leaderBoard.Values)
        {
            if (i >= 6) break;
            fameTMP.text += "명성도 : " + fame + "\n";
            i++;
        }

        IsReq = false;
    }

    private Dictionary<string, int> SoltDictionary(Dictionary<string, int> d)
    {
        var temp = d.OrderByDescending(x => x.Value);
        Dictionary<string, int> dic = new Dictionary<string, int>();
        foreach(var pair in temp)
            dic.Add(pair.Key, pair.Value);
        return dic;
    }
}
