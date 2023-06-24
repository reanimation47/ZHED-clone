using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StartMenu.StarScreen
{
    public class StartScreenController : MonoBehaviour
    {
        BaseConfiguration configuration = new BaseConfiguration();
        [SerializeField] private AlphaMask AlphaMask;

        private void Awake()
        {
            IStartMenu.Load_StartScreenController(this);
        }

        public void PlayButtonClicked()
        {
            StartCoroutine(GoToPacksSelectScreen());
        }
        IEnumerator GoToPacksSelectScreen()
        {
            AlphaMask.ToggleBackgroundBlur(1, 0.2f);
            yield return new WaitForSeconds(1f);
            AsyncOperation async_load = SceneManager.LoadSceneAsync(configuration.PackSelectSceneName);
            while (!async_load.isDone)
            {
                yield return null;
            }
        }
    }
}
