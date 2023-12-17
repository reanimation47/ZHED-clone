using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public static class CoreInfomation 
    {
        public static readonly string StartMenuSceneName = "StartMenu";
        public static readonly string PackSelectSceneName = "LevelPacksSelect";
        public static readonly string LevelSelectSceneName = "LevelsSelect";
        public static readonly string SettingsMenuSceneName = "Settings";

        public static readonly string LevelsSceneNameFormat = "Pack{0}Level{1}";

        public static readonly string PlayerPrefs_CurrentLevelIndex_Key = "PlayerPrefs_CurrentLevelIndex_Key";
        public static readonly string PlayerPrefs_CurrentPackIndex_Key = "PlayerPrefs_CurrentPackIndex_Key";

        public static readonly string PlayerPrefs_UnlockedLevelIndex_Key = "PlayerPrefs_UnlockedLevelIndex_Key";
        public static readonly string PlayerPrefs_UnlockedPackIndex_Key = "PlayerPrefs_UnlockedPackIndex_Key";
        public static readonly string PlayerPrefs_CurrentSystemBGMVolume_Key = "PlayerPrefs_CurrentSystemBGMVolume_Key";
        public static readonly string PlayerPrefs_CurrentSystemSFXVolume_Key = "PlayerPrefs_CurrentSystemSFXVolume_Key";

        public static readonly int PacksCount = 4; //At current point anything pack above 2 is just a clone of pack 2
        public static readonly int LevelsPerPack = 12;
    }
}

