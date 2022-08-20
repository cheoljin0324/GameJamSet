using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class Working : MonoBehaviour
{
    private GameObject nowItem;

    public void SetNowItem(int index)
    {
        nowItem = transform.GetChild(index).gameObject;
        nowItem.SetActive(true);
        nowItem.GetComponent<Animator>().SetBool("Done", false);
        Invoke("SetFalse", DataManager.Instance.UserData.coolTimes[index] - 0.25f);
    }

    public void SetFalse()
    {
        nowItem.GetComponent<Animator>().SetBool("Done", true);
        Invoke("SetOff", 0.25f);
    }

    public void SetOff()
    {
        nowItem.SetActive(false);
    }
}
