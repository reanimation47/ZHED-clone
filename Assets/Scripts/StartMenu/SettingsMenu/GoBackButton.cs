using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StartMenu.Settings
{
    public class GoBackButton : BasicButtonClass
    {
        public override void ButtonAction()
        {
            SceneManager.LoadScene(CoreInfomation.StartMenuSceneName);
        }
    }

}
