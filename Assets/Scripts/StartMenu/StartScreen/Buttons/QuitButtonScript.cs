using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StartMenu.StarScreen.Buttons
{
    public class QuitButtonScript : BasicButtonClass
    {
        public override void ButtonAction()
        {
            Application.Quit();
        }
    }
}

