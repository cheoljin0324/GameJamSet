using UnityEngine;
using UnityEngine.UI;

namespace SEH00N
{
    public class Processing : MonoBehaviour
    {
        private int[] state = { 0, 0, 0 };
        private Button button = null;
        public int Index { get; set; } = 0;

        private void Awake()
        {
            button = GetComponent<Button>();
        }

        public void DoProcessing()
        {
            state[Index]++;
            button.interactable = false;
        }
    }
}
