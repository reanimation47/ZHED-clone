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
            IStartMenu.LevelSelected(LevelIndex);
        }
    }

}
