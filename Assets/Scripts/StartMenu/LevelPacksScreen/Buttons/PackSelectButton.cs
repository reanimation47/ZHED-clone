using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Core;

namespace StartMenu.LevelPacksScreen.Buttons
{
    public class PackSelectButton : BasicButtonClass
    {
        private int PackIndex;
        public TextMeshProUGUI title;
        public Image img;
        private Color LockedColor = new Color(145f / 255f, 151f / 255f, 174f / 255f);

        private bool PackUnlocked = false;
        public void PackInit(int _index)
        {
            PackIndex = _index;
            CheckProgress();
            SetTitle();
        }

        public void CheckProgress()
        {
            int CurrentUnlockedPack = PlayerPrefs.GetInt(CoreInfomation.PlayerPrefs_UnlockedPackIndex_Key);
            Debug.Log(CurrentUnlockedPack);
            if (PackIndex > CurrentUnlockedPack)
            {
                Debug.Log("Locked");
                img.color = LockedColor;
            }else
            {
                PackUnlocked = true;
            }
        }

        private void SetTitle()
        {
            if (!PackUnlocked)
            {
                title.text = "Locked";
                return;
            }

            if (PackIndex < 10)
            {
                title.text = "Pack " + "0" +PackIndex;
            }else
            {
                title.text = "Pack " + PackIndex;
            }

            
        }
        
        public override void ButtonAction()
        {
            if (!PackUnlocked) { return; }
            IStartMenu.LevelPackSelected(PackIndex);
        }
    }
}

