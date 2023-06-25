using System.Collections;
using System.Collections.Generic;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace StartMenu.LevelsScreen
{
    public class LevelsButton : BasicButtonClass
    {
        private int LevelIndex;
        public TextMeshProUGUI title;

        public Image img;
        private Color LockedColor = new Color(145f / 255f, 151f / 255f, 174f / 255f);

        private bool LevelUnlocked = false;

        private BaseConfiguration configuration = new BaseConfiguration();

        public void LevelButtonInit(int _index)
        {
            LevelIndex = _index;
            CheckProgress();
            SetTitle();
        }

        public void CheckProgress()
        {
            int CurrentUnlockedLevel = PlayerPrefs.GetInt(CoreInfomation.PlayerPrefs_UnlockedLevelIndex_Key);
            int CurrentUnlockedPack = PlayerPrefs.GetInt(CoreInfomation.PlayerPrefs_UnlockedPackIndex_Key);

            if (IStartMenu.GetCurrentSelectedPack() < CurrentUnlockedPack)
            {
                LevelUnlocked = true;
            }
            else if (IStartMenu.GetCurrentSelectedPack() == CurrentUnlockedPack)
            {
                if (LevelIndex > CurrentUnlockedLevel)
                {
                    LevelUnlocked = false;
                    img.color = LockedColor;
                }else
                {
                    LevelUnlocked = true;
                }
            }

        }

        private void SetTitle()
        {
            if (!LevelUnlocked)
            {
                title.text = "X";
                return;
            }

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
            if (!LevelUnlocked) { return; }
            Debug.Log(string.Format(configuration.LevelsSceneNameFormat, IStartMenu.GetCurrentSelectedPack(), LevelIndex));
            IStartMenu.LevelSelected(LevelIndex);
        }
    }

}
