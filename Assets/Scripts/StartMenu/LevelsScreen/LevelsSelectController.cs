using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Core;
namespace StartMenu.LevelsScreen
{
    public class LevelsSelectController : MonoBehaviour
    {
        public GameObject Prefab_LevelSelectButton;
        public AlphaMask AlphaMask;

        private BaseConfiguration configuration = new BaseConfiguration();
        public int LevelsPerPack = 0;
        // Start is called before the first frame update
        void Awake()
        {
            IStartMenu.Load_LevelsSelectController(this);
            LevelsPerPack = configuration.LevelsPerPack;
        }

        void Start()
        {
            CreateLevelsButton();
        }

        private void CreateLevelsButton()
        {
            for (int i = 1; i <= LevelsPerPack; i++)
            {
                GameObject _pack = Instantiate(Prefab_LevelSelectButton, gameObject.transform);
                _pack.GetComponent<LevelsButton>().LevelButtonInit(i);
            }
        }

        public void LevelSelected(int index)
        {
            StartCoroutine(Co_LevelSelected());
        }
        IEnumerator Co_LevelSelected()
        {
            AlphaMask.ToggleBackgroundBlur(1, configuration.TransitionSpeedBetweenScreens);
            yield return new WaitForSeconds(configuration.TransitionDelayBetweenScreens);

            int CurrentPackIndex = IStartMenu.GetCurrentSelectedPack();
            int CurrentLevelIndex = IStartMenu.GetCurrentSelectedLevel();
            string SceneNameFormat = configuration.LevelsSceneNameFormat;
            string FinalSceneName = string.Format(SceneNameFormat, CurrentPackIndex, CurrentLevelIndex);
            SaveInfoToPlayerPrefs(CurrentPackIndex, CurrentLevelIndex);

            AsyncOperation async_load = SceneManager.LoadSceneAsync(FinalSceneName);
            while (!async_load.isDone)
            {
                yield return null;
            }
        }

        private void SaveInfoToPlayerPrefs(int PackIndex, int LevelIndex)
        {
            PlayerPrefs.SetInt(CoreInfomation.PlayerPrefs_CurrentLevelIndex_Key, LevelIndex);
            PlayerPrefs.SetInt(CoreInfomation.PlayerPrefs_CurrentPackIndex_Key, PackIndex);
        }
    }
}

