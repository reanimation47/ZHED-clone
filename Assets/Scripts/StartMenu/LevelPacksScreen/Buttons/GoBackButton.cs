using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Core;
namespace StartMenu.LevelPacksScreen.Buttons
{
    public class GoBackButton : BasicButtonClass
    {
        public override void ButtonAction()
        {
            SceneManager.LoadScene(CoreInfomation.StartMenuSceneName);
        }
    }
}

