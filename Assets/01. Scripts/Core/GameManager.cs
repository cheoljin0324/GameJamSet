using UnityEngine;

namespace Core 
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public int[] temp = new int[28];

        private void Awake()
        {
            Initialize();
        }
    }
}
