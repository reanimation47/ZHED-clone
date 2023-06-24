using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StartMenu.LevelPacksScreen
{
    public class LevelPacksController : MonoBehaviour
    {
        public GameObject Prefab_PackSelectButton;
        public AlphaMask AlphaMask;

        private BaseConfiguration configuration = new BaseConfiguration();
        public int PacksCount = 0;
        // Start is called before the first frame update
        void Awake()
        {
            IStartMenu.Load_LevelPacksController(this);
            PacksCount = configuration.PacksCount;
        }

        void Start()
        {
            CreatePacksButton();
        }

        private void CreatePacksButton()
        {
            for (int i = 1; i <= PacksCount; i++)
            {
                GameObject _pack = Instantiate(Prefab_PackSelectButton, gameObject.transform);
                _pack.GetComponent<Buttons.PackSelectButton>().PackInit(i);
            }
        }

        public void LevelPackSelected(int index)
        {
            StartCoroutine(Co_LevelPackSelected());
        }
        IEnumerator Co_LevelPackSelected()
        {
            AlphaMask.ToggleBackgroundBlur(1, 0.2f);
            yield return new WaitForSeconds(1f);
            AsyncOperation async_load = SceneManager.LoadSceneAsync(configuration.LevelSelectSceneName);
            while (!async_load.isDone)
            {
                yield return null;
            }
        }
    }
}

