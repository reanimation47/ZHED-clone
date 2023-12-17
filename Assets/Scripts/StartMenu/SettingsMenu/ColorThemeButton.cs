using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace StartMenu
{
    public enum ColorTheme
    {
        DarkMode,
        LightMode
    }
    public class ColorThemeButton : BasicButtonClass
    {
        public ColorTheme colorTheme;
        public override void ButtonAction()
        {
            //This is bad and ugly af but got like 15mins to code all if this so..
            if (colorTheme == ColorTheme.DarkMode)
            {
                PlayerPrefs.SetString(CoreInfomation.PlayerPrefs_CurrentSystemThemeMode_Key, CoreInfomation.ColorTheme_DarkMode);
            }
            if (colorTheme == ColorTheme.LightMode)
            {
                PlayerPrefs.SetString(CoreInfomation.PlayerPrefs_CurrentSystemThemeMode_Key, CoreInfomation.ColorTheme_LightMode);
            }
        }
    }
}

