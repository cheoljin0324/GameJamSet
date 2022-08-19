using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gobuttonscrip : MonoBehaviour
{

    Button btn;

     GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.GetComponent<Button>();
        obj = GameObject.Find("LeftObj");
        btn.onClick.AddListener(obj.GetComponent<Nodestroy>().GameGo);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
