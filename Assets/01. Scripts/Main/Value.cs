using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Value : MonoBehaviour
{
    [SerializeField]
    GameObject jewelryManager;

    public int foo1=0; //얻는 광물 개수
    [SerializeField] TextMeshProUGUI txtvalue; //value 표시용
    [SerializeField] TextMeshProUGUI txtLeft; //left 표시용
    [SerializeField] Button btn1; //+
    [SerializeField] Button btn2; //-
    void Start(){
        jewelryManager=GameObject.Find("JewelryManager");

        btn1=transform.GetChild(1).GetComponent<Button>();
        btn2=transform.GetChild(2).GetComponent<Button>();

        btn1.onClick.AddListener(buttonPlus);
        btn2.onClick.AddListener(buttonMinus);

        txtvalue=transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        txtLeft=GameObject.Find("valueLeft").GetComponent<TextMeshProUGUI>();

        txtupdate();
    }
    public void buttonPlus(){ //개수 더하기
        if(jewelryManager.GetComponent<JewelryManager>().left!=0){
            jewelryManager.GetComponent<JewelryManager>().left--;
            foo1++;
            txtupdate();
            }
    }
    public void buttonMinus(){ //개수 빼기
    if(foo1>0){
        jewelryManager.GetComponent<JewelryManager>().left++;
        foo1--;
        txtupdate();
        }
    }
    void txtupdate()
    { // 텍스트 업데이트.
        txtvalue.text = foo1.ToString();
        txtLeft.text = "채집 가능 광석 개수 : " + jewelryManager.GetComponent<JewelryManager>().left.ToString();
    }
}
