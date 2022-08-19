using UnityEngine;

namespace Core 
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private void Awake()
        {
            Initialize();
        }
    }
}
