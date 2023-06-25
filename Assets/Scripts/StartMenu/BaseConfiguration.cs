using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
namespace StartMenu
{
    public enum PlayerPrefsKey
    {

    }

    public class BaseConfiguration 
    {
        public readonly string PackSelectSceneName = CoreInfomation.PackSelectSceneName;
        public readonly string LevelSelectSceneName = CoreInfomation.LevelSelectSceneName;
        public readonly string LevelsSceneNameFormat = CoreInfomation.LevelsSceneNameFormat;
        public readonly int PacksCount = CoreInfomation.PacksCount;
        public readonly int LevelsPerPack = CoreInfomation.LevelsPerPack;

        public readonly float TransitionSpeedBetweenScreens = 0.3f;
        public readonly float TransitionDelayBetweenScreens = 0.5f;
    }
}


