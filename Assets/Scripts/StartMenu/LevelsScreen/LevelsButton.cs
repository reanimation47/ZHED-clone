using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace StartMenu.LevelsScreen
{
    public class LevelsButton : BasicButtonClass
    {
        private int LevelIndex;
        public TextMeshProUGUI title;

        private BaseConfiguration configuration = new BaseConfiguration();

        public void LevelButtonInit(int _index)
        {
            LevelIndex = _index;
            SetTitle();
        }

        private void SetTitle()
        {
            if (LevelIndex < 10)
            {
                title.text = "0" + LevelIndex;
            }
            else
            {
                title.text = ""+LevelIndex;
            }
        }

        public override void ButtonAction()
        {
            Debug.Log(string.Format(configuration.LevelsSceneNameFormat, IStartMenu.GetCurrentSelectedPack(), LevelIndex));
            IStartMenu.LevelSelected(LevelIndex);
        }
    }

}
