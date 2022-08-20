using Core;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;
using UnityEngine.Events;

public class SetName : MonoBehaviour
{
    [SerializeField] UnityEvent doPopDown = null;
    [SerializeField] GameObject nameSettingPanel = null;
    private TMP_InputField field = null;

    void Start()
    {
        if(DataManager.Instance.UserData.name != "") return;
        
        nameSettingPanel.SetActive(true);
    }

    public void NameSet()
    {
        if(field.text.Length >= 6 || field.text.Length <= 0)
        {
            TextPrefab temp = PoolManager.Instance.Pop("TextPrefab") as TextPrefab;
            temp.SetText("1~5글자의 이름을 입력해주세요.");
            return;
        }

        DataManager.Instance.UserData.name = field.text;
        string JSON = JsonConvert.SerializeObject(new Client.Packet(DataManager.Instance.UserData.name, 0));
        Client.Instance.SendMessages(JSON);

        doPopDown?.Invoke();
    }
}
