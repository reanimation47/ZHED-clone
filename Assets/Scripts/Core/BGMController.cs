using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Sound
{
    public class BGMController : MonoBehaviour
    {
        [SerializeField] private AudioSource _bgm;

        public static BGMController bgmInstance;

        private void Awake()
        {
            if (bgmInstance == null)
            {
                bgmInstance = this;
                DontDestroyOnLoad(gameObject);
            }else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            if (PlayerPrefs.GetFloat(CoreInfomation.PlayerPrefs_CurrentSystemBGMVolume_Key,-1f) != -1)
            {
                float prevVolume = PlayerPrefs.GetFloat(CoreInfomation.PlayerPrefs_CurrentSystemBGMVolume_Key,-1f);
                _bgm.volume = prevVolume;
            }
        }


        public float GetCurrentBGMVolume()
        {
            return _bgm.volume;
        }
        public void BGMVolume(float volume)
        {
            _bgm.volume = volume;
        }



    }
}

