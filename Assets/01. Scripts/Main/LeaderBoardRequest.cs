using Newtonsoft.Json;
using UnityEngine;
using Core;

public class LeaderBoardRequest : MonoBehaviour
{
    public void Request()
    {
        Client.Instance.SendMessages("req");
        
        Client.Instance.IsReq = true;
    }
}
