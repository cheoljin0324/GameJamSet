using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCredit : MonoBehaviour
{
    [SerializeField] private GameObject credit;

    public void PlayCreditAnimation()
    {
        credit.SetActive(true);
    }

    public void StopCreditAnimation()
    {
        credit.SetActive(false);
    }
}
