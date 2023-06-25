using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Core;

namespace StartMenu.StarScreen
{
    public class StartScreenController : MonoBehaviour
    {
        BaseConfiguration configuration = new BaseConfiguration();
        [SerializeField] private AlphaMask AlphaMask;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            IStartMenu.Load_StartScreenController(this);
            GeneratePlayerPrefsForProgress();
            DebugCurrentProgress();
        }

        private void DebugCurrentProgress()
        {
            if (PlayerPrefs.HasKey(CoreInfomation.PlayerPrefs_UnlockedLevelIndex_Key))
            {
                Debug.Log("Current Pack: " + PlayerPrefs.GetInt(CoreInfomation.PlayerPrefs_UnlockedPackIndex_Key));
                Debug.Log("Current Level: " + PlayerPrefs.GetInt(CoreInfomation.PlayerPrefs_UnlockedLevelIndex_Key));
            }
        }

        private void GeneratePlayerPrefsForProgress()
        {
            if (PlayerPrefs.HasKey(CoreInfomation.PlayerPrefs_UnlockedLevelIndex_Key)) { return; } //Already generated
            PlayerPrefs.SetInt(CoreInfomation.PlayerPrefs_UnlockedLevelIndex_Key, 1);
            PlayerPrefs.SetInt(CoreInfomation.PlayerPrefs_UnlockedPackIndex_Key, 1);
            Debug.Log("PlayerPrefs For Progress generated!");
        }

        public void PlayButtonClicked()
        {
            StartCoroutine(GoToPacksSelectScreen());
        }
        IEnumerator GoToPacksSelectScreen()
        {
            AlphaMask.ToggleBackgroundBlur(1, configuration.TransitionSpeedBetweenScreens);
            yield return new WaitForSeconds(configuration.TransitionDelayBetweenScreens);
            AsyncOperation async_load = SceneManager.LoadSceneAsync(configuration.PackSelectSceneName);
            while (!async_load.isDone)
            {
                yield return null;
            }
        }
    }
}

