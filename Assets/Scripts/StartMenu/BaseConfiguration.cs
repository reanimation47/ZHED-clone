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
        public readonly string PackSelectSceneName = "LevelPacksSelect";
        public readonly string LevelSelectSceneName = "LevelsSelect";
        public readonly string LevelsSceneNameFormat = "Pack{0}Level{1}";
        public readonly int PacksCount = 5;
        public readonly int LevelsPerPack = 12;
    }
}


