using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            AlphaMask.ToggleBackgroundBlur(1, 0.2f);
            yield return new WaitForSeconds(1f);
            //AsyncOperation async_load = SceneManager.LoadSceneAsync(configuration.PackSelectSceneName);
            //while (!async_load.isDone)
            //{
            //    yield return null;
            //}
        }
    }
}

