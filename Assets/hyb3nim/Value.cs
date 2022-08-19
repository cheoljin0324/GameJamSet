using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Value : MonoBehaviour
{
    [SerializeField]
    GameObject nodestroy;

    int foo1=0; //얻는 광물 개수
    [SerializeField] Text txtvalue; //value 표시용
    [SerializeField] Text txtLeft; //left 표시용
    [SerializeField] Button btn1; //+
    [SerializeField] Button btn2; //-
    void Start(){
        nodestroy=GameObject.Find("LeftObj");

        btn1=transform.GetChild(1).GetComponent<Button>();
        btn2=transform.GetChild(2).GetComponent<Button>();

        btn1.onClick.AddListener(buttonPlus);
        btn2.onClick.AddListener(buttonMinus);

        txtvalue=transform.GetChild(3).GetComponent<Text>();
        txtLeft=GameObject.Find("valueLeft").GetComponent<Text>();

        txtupdate();

        
    }
    public void buttonPlus(){ //개수 더하기
        if(nodestroy.GetComponent<Nodestroy>().left!=0){
            nodestroy.GetComponent<Nodestroy>().left--;
            foo1++;
            txtupdate();
            }
    }
    public void buttonMinus(){ //개수 빼기
    if(foo1>0){
        nodestroy.GetComponent<Nodestroy>().left++;
        foo1--;
        txtupdate();
        }
    }
    void txtupdate(){ // 텍스트 업데이트.
        txtvalue.text=foo1.ToString();
        txtLeft.text=nodestroy.GetComponent<Nodestroy>().left.ToString()+" Left";
    }
}
