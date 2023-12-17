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

    }
}

