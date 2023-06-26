using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core;

namespace GamePlay.InGameUI
{
    public class InGameUIController : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI LevelInfo;
        
        void Start()
        {
            SetupLevelInfo();
        }

        private void SetupLevelInfo()
        {
            int CurrentLevelIndex = PlayerPrefs.GetInt(CoreInfomation.PlayerPrefs_CurrentLevelIndex_Key);
            int CurrentPackIndex = PlayerPrefs.GetInt(CoreInfomation.PlayerPrefs_CurrentPackIndex_Key);
            LevelInfo.text = $"Pack {CurrentPackIndex}\nLevel {CurrentLevelIndex}";
        }
    }
}


