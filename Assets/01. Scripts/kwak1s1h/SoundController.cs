using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;

namespace kwak1s1h
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private Slider bgmSlider;
        [SerializeField] private Slider effectSlider;

        private void Start()
        {
            SetBGMVolume();
            SetEffectVolume();
        }

        public void SetBGMVolume()
        {
            AudioManager.Instance.BGMSource.volume = bgmSlider.value;
            PlayerPrefs.SetFloat("BGM",  AudioManager.Instance.BGMSource.volume);
        }
        public void SetEffectVolume()
        {
            AudioManager.Instance.EffectSource.volume = effectSlider.value;
            PlayerPrefs.SetFloat("EFFECT",  AudioManager.Instance.EffectSource.volume);
        }
    }
}
