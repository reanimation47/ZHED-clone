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

            int NewLevelIndex = CurrentLevelIndex +1;
            int NewPackIndex = CurrentPackIndex;

            if (NewLevelIndex > CoreInfomation.LevelsPerPack)
            {
                NewLevelIndex = 1;
                NewPackIndex += 1;
            }
            PlayerPrefs.SetInt(CoreInfomation.PlayerPrefs_CurrentLevelIndex_Key, NewLevelIndex);
            PlayerPrefs.SetInt(CoreInfomation.PlayerPrefs_CurrentPackIndex_Key, NewPackIndex);

            string NextLevelSceneName = string.Format(CoreInfomation.LevelsSceneNameFormat, NewPackIndex, NewLevelIndex);
            SceneManager.LoadScene(NextLevelSceneName);
            //string.Format(configuration.LevelsSceneNameFormat, IStartMenu.GetCurrentSelectedPack(), LevelIndex)
        }

    }

   

}

