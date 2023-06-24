using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace StartMenu.LevelPacksScreen.Buttons
{
    public class PackSelectButton : BasicButtonClass
    {
        private int PackIndex;
        public TextMeshProUGUI title;


        public void PackInit(int _index)
        {
            PackIndex = _index;
            SetTitle();
        }

        private void SetTitle()
        {
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
            IStartMenu.LevelPackSelected(PackIndex);
        }
    }
}

