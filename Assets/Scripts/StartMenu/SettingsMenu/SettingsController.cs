using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Sound;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    void Start()
    {
        musicSlider.value = BGMController.bgmInstance.GetCurrentBGMVolume();
        SFXSlider.value = SFXController.sfxInstance.GetCurrentSFXVolume();
    }
    public Slider musicSlider,SFXSlider;
    public void AdjustBGMVolume()
    {
        BGMController.bgmInstance.BGMVolume(musicSlider.value);
        PlayerPrefs.SetFloat(CoreInfomation.PlayerPrefs_CurrentSystemBGMVolume_Key, musicSlider.value);
    }
    public void AdjustSFXVolume()
    {
        SFXController.sfxInstance.SFXVolume(SFXSlider.value);
        PlayerPrefs.SetFloat(CoreInfomation.PlayerPrefs_CurrentSystemSFXVolume_Key, SFXSlider.value);
    }
}
