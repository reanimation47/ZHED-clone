using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Sound
{
    public class SFXController : MonoBehaviour
    {
        [SerializeField] private AudioSource _sfx;
        [SerializeField] private AudioClip _genericButtonSFX;
        [SerializeField] private AudioClip _genericCloseButtonSFX;
        [SerializeField] private AudioClip _genericTileSFX;
        [SerializeField] private AudioClip _genericVictorySFX;


        public static SFXController sfxInstance;

        private void Awake()
        {
            if (sfxInstance == null)
            {
                sfxInstance = this;
                DontDestroyOnLoad(gameObject);
            }else
            {
                Destroy(gameObject);
            }
        }
        void Start()
        {
            if (PlayerPrefs.GetFloat(CoreInfomation.PlayerPrefs_CurrentSystemSFXVolume_Key,-1f) != -1)
            {
                float prevVolume = PlayerPrefs.GetFloat(CoreInfomation.PlayerPrefs_CurrentSystemSFXVolume_Key,-1f);
                _sfx.volume = prevVolume;
            }
        }

        public void PlayButtonClickSFX()
        {
            _sfx.clip = _genericButtonSFX;
            _sfx.Play();
        }
        public void PlayCloseButtonClickSFX()
        {
            _sfx.clip = _genericCloseButtonSFX;
            _sfx.Play();
        }
        public void PlayTileClickSFX()
        {
            _sfx.clip = _genericTileSFX;
            _sfx.Play();
        }

        public void PlayVictorySFX()
        {
            _sfx.clip = _genericVictorySFX;
            _sfx.Play();
        }
        public float GetCurrentSFXVolume()
        {
            return _sfx.volume;
        }
        public void SFXVolume(float volume)
        {
            _sfx.volume = volume;
        }


    }
}

