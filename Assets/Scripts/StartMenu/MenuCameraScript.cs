using System.Collections;
using System.Collections.Generic;
using Codice.Client.Common.GameUI;
using Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace StartMenu
{
    public class MenuCameraScript : MonoBehaviour
    {
        [SerializeField] Camera cam;
        //This is bad, 
        private void Awake()
        {
            UpdateBGColor();
        }
        private void Update()
        {
            UpdateBGColor();
        }

        private void UpdateBGColor()
        {
            string colorTheme = PlayerPrefs.GetString(CoreInfomation.PlayerPrefs_CurrentSystemThemeMode_Key, "None");
            if (colorTheme != "None")
            {
                if (colorTheme == CoreInfomation.ColorTheme_DarkMode)
                {
                    PlayerPrefs.SetString(CoreInfomation.PlayerPrefs_CurrentSystemThemeMode_Key, CoreInfomation.ColorTheme_DarkMode);
                    cam.backgroundColor = CoreInfomation.MenuBG_DarkMode;
                } 

                if (colorTheme == CoreInfomation.ColorTheme_LightMode)
                {
                    PlayerPrefs.SetString(CoreInfomation.PlayerPrefs_CurrentSystemThemeMode_Key, CoreInfomation.ColorTheme_LightMode);
                    cam.backgroundColor = CoreInfomation.MenuBG_LightMode;
                } 
            }else
            {
                cam.backgroundColor = CoreInfomation.MenuBG_DarkMode;
            }

        }
    }
}

