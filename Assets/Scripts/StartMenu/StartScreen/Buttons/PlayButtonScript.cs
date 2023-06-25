using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StartMenu.StarScreen.Buttons
{
    public class PlayButtonScript : BasicButtonClass
    {
        public override void ButtonAction()
        {
            IStartMenu.PlayButtonClicked();
        }
    }
}

