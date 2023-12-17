using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Core;

namespace StartMenu.StarScreen
{
    public class StartScreenController : MonoBehaviour
    {
        //  TODO:
        // +GoTo<Name>Screen functions are re-using the exact same lines of code -> make it 1 generic go to xxx screen function that takes scene name as a param
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
            AsyncOperation async_load = SceneManager.LoadSceneAsync(CoreInfomation.PackSelectSceneName);
            while (!async_load.isDone)
            {
                yield return null;
            }
        }

        public void SettingsButtonClicked()
        {
            StartCoroutine(GoToSettingsScreen());
        }
        IEnumerator GoToSettingsScreen()
        {
            AlphaMask.ToggleBackgroundBlur(1, configuration.TransitionSpeedBetweenScreens);
            yield return new WaitForSeconds(configuration.TransitionDelayBetweenScreens);
            //TODO: Settings Scene name here
            AsyncOperation async_load = SceneManager.LoadSceneAsync(CoreInfomation.SettingsMenuSceneName);
            while (!async_load.isDone)
            {
                yield return null;
            }
        }
    }
}

