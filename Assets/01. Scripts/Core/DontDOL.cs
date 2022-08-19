using UnityEngine;

namespace Core
{
    public class DontDOL : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(transform.root.gameObject);
        }
    }
}
