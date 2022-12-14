using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance = null;

        [SerializeField] AudioSource bgmSource, effectSource = null;
        public AudioSource BGMSource => bgmSource;
        public AudioSource EffectSource => effectSource;
        [SerializeField] List<AudioClip> clipList = new List<AudioClip>();
        private Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();
        private float bV, eV = 0;

        private void Awake()
        {
            if(Instance == null) { Instance = this; DontDestroyOnLoad(transform.root.gameObject); }
            else { Destroy(transform.root.gameObject); }
            
            bV = PlayerPrefs.GetFloat("BGM", 0.5f);
            eV = PlayerPrefs.GetFloat("EFFECT", 0.5f); 

            BGMSource.volume = bV;
            EffectSource.volume = eV;
        }

        private void Start()
        {
            foreach(AudioClip c in clipList)
                clips.Add(c.name, c);

            PlayBGM("Lets Go_BGM");
        }

        private void OnDisable()
        {
            PlayerPrefs.SetFloat("BGM", BGMSource.volume); 
            PlayerPrefs.SetFloat("EFFECT", EffectSource.volume);
        }

        public void PlayBGM(string clipName)
        {
            if(!clips.ContainsKey(clipName)) return;

            BGMSource.clip = clips[clipName];
            BGMSource.Play();
        }

        public void PlayClip(string clipName)
        {
            if(!clips.ContainsKey(clipName)) return;

            EffectSource.clip = clips[clipName];
            EffectSource.Play();
        }

        public void PauseBGM()
        {
            BGMSource.Pause();
        }
    }
}