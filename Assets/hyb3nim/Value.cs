using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Value : MonoBehaviour
{
    int left=30; //광물 개수 제한
    int foo1=0; //얻는 광물 개수
    public Text txtvalue; //value 표시용
    public Text txtLeft; //left 표시용
    [SerializeField] Button btn1;
    [SerializeField] Button btn2;
    void Start(){
        txtvalue=transform.GetChild(2).GetComponent<Text>();
        btn1=transform.GetChild(0).GetComponent<Button>();
        btn2=transform.GetChild(1).GetComponent<Button>();
        txtLeft=GameObject.Find("valueLeft").GetComponent<Text>();
        btn1.onClick.AddListener(buttonPlus);
        btn2.onClick.AddListener(buttonMinus);
        txtvalue.text=foo1.ToString();
        txtLeft.text=left.ToString()+"Left";
    }
    public void buttonPlus(){
        if(left!=0){
            left--;
            foo1++;
            Debug.Log("더함");
            txtvalue.text=foo1.ToString();
            txtLeft.text=left.ToString()+" Left";
            }
        else Debug.Log("안더함");
    }
    public void buttonMinus(){
    if(foo1>0){
        left++;
        foo1--;
        Debug.Log("뺌");
        txtvalue.text=foo1.ToString();
        txtLeft.text=left.ToString()+"Left";
        }
    else Debug.Log("안뺌");
    }
}
