using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStart : MonoBehaviour
{
    public void DoStart()
    {
        OrderManager.Instance.dayCleared = false;
        OrderManager.Instance.CurrentTime = 0;
    }
}
