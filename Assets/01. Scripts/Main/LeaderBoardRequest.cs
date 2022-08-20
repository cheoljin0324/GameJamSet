using Newtonsoft.Json;
using UnityEngine;
using Core;

public class LeaderBoardRequest : MonoBehaviour
{
    public void Request()
    {
        UserData ud = DataManager.Instance.UserData;
        string JSON = JsonConvert.SerializeObject(new Client.Packet(ud.name, ud.fame));
        Client.Instance.SendMessages(JSON);
    }
}
