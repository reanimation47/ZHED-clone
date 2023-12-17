using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace StartMenu
{
    public enum SettingsButtonType 
    {
        Vibration,
    }

    public class SettingsButton : BasicButtonClass
    {
        public GameObject ToggleON, ToggleOFF;

        private void Start()
        {
            bool isToggleON = PlayerPrefs.GetInt(CoreInfomation.PlayerPrefs_CurrentSystemVibrationMode_Key, -1) == 1;
            if (isToggleON)
            {
                PlayerPrefs.SetInt(CoreInfomation.PlayerPrefs_CurrentSystemVibrationMode_Key, 1);
            }else
            {
                PlayerPrefs.SetInt(CoreInfomation.PlayerPrefs_CurrentSystemVibrationMode_Key, 0);
            }
            ToggleON.SetActive(isToggleON);
            ToggleOFF.SetActive(!isToggleON);
        }

        public override void ButtonAction()
        {
            bool isToggleON = PlayerPrefs.GetInt(CoreInfomation.PlayerPrefs_CurrentSystemVibrationMode_Key, -1) == 1;
            isToggleON = !isToggleON;
            if (isToggleON)
            {
                PlayerPrefs.SetInt(CoreInfomation.PlayerPrefs_CurrentSystemVibrationMode_Key, 1);
            }else
            {
                PlayerPrefs.SetInt(CoreInfomation.PlayerPrefs_CurrentSystemVibrationMode_Key, 0);
            }
            ToggleON.SetActive(isToggleON);
            ToggleOFF.SetActive(!isToggleON);

        }

    }
}