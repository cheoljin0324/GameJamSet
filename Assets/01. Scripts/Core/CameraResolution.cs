using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class CameraResolution : MonoBehaviour
    {
        void Start()
        {
            Screen.SetResolution(1920, 1080, true);
        }
    }
}
