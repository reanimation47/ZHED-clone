using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Core.Button;
using Core;

namespace GamePlay
{
    public class SideButtons : BaseButton
    {
        private enum ButtonType { Restart, Quit}
        [SerializeField] private ButtonType button_type;
        
        public override void ButtonAction()
        {
            if (button_type == ButtonType.Restart)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                SceneManager.LoadScene(CoreInfomation.LevelSelectSceneName);
            }
        }
    }

}
