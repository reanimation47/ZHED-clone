using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StartMenu.StarScreen.Buttons
{
    public class SettingsButtonScript : BasicButtonClass
    {
        public override void ButtonAction()
        {
            IStartMenu.SettingsButtonClicked();
        }
    }
}

