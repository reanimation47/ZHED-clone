using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class CoreInterface : MonoBehaviour
    {
        public static void LoadNextLevel()
        {
            int CurrentLevelIndex = PlayerPrefs.GetInt(CoreInfomation.PlayerPrefs_CurrentLevelIndex_Key);
            int CurrentPackIndex = PlayerPrefs.GetInt(CoreInfomation.PlayerPrefs_CurrentPackIndex_Key);

            int NextLevelIndex = CurrentLevelIndex +1;
            int NextPackIndex = CurrentPackIndex;

            if (NextLevelIndex > CoreInfomation.LevelsPerPack)
            {
                NextLevelIndex = 1;
                NextPackIndex += 1;
            }
            SaveNewProgress(NextLevelIndex, NextPackIndex);
            PlayerPrefs.SetInt(CoreInfomation.PlayerPrefs_CurrentLevelIndex_Key, NextLevelIndex);
            PlayerPrefs.SetInt(CoreInfomation.PlayerPrefs_CurrentPackIndex_Key, NextPackIndex);

            string NextLevelSceneName = string.Format(CoreInfomation.LevelsSceneNameFormat, NextPackIndex, NextLevelIndex);
            SceneManager.LoadScene(NextLevelSceneName);
            //string.Format(configuration.LevelsSceneNameFormat, IStartMenu.GetCurrentSelectedPack(), LevelIndex)
        }

        public static void SaveNewProgress(int NextLevelIndex, int NextPackIndex)
        {
            int CurrentLevelProgress = PlayerPrefs.GetInt(CoreInfomation.PlayerPrefs_UnlockedLevelIndex_Key);
            int CurrentPackProgress = PlayerPrefs.GetInt(CoreInfomation.PlayerPrefs_UnlockedPackIndex_Key);

            if (NextPackIndex == CurrentPackProgress)
            {
                if (NextLevelIndex > CurrentLevelProgress)
                {
                    PlayerPrefs.SetInt(CoreInfomation.PlayerPrefs_UnlockedLevelIndex_Key, CurrentLevelProgress + 1);
                }
            }else if(NextPackIndex > CurrentPackProgress)
            {
                PlayerPrefs.SetInt(CoreInfomation.PlayerPrefs_UnlockedPackIndex_Key, CurrentPackProgress + 1);
                PlayerPrefs.SetInt(CoreInfomation.PlayerPrefs_UnlockedLevelIndex_Key, 1);
            }
        }

    }

   

}

