using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class AudioPlayer : MonoBehaviour
{
    public void PlayClipEff(string clipName)
    {
        AudioManager.Instance.PlayClip(clipName);
    }
    public void PlayClipBGM(string clipName)
    {
        AudioManager.Instance.PlayBGM(clipName);
    }
}
