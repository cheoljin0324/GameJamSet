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
            bgmSlider.value = AudioManager.Instance.BGMSource.volume;
            effectSlider.value = AudioManager.Instance.EffectSource.volume;
        }

        public void SetBGMVolume()
        {
            AudioManager.Instance.BGMSource.volume = bgmSlider.value;
        }
        public void SetEffectVolume()
        {
            AudioManager.Instance.EffectSource.volume = effectSlider.value;
        }
    }
}
