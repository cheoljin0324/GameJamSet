using UnityEngine;
using UnityEngine.UI;

public class Processing : MonoBehaviour
{
    [SerializeField] int count;
    private int[] state = { 0, 0, 0 };
    private Button button = null;
    public int Index { get; set; } = 0;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void DoProcessing()
    {
        if(JewelryManager.Instance.haveJewelry[count] <= 0) return;
        JewelryManager.Instance.haveJewelry[count]--;
        state[Index]++;
        button.interactable = false;
    }

    public int SendOutState(int index)
    {
        return state[index];
    }
}