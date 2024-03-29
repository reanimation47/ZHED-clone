using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StartMenu
{
    public interface IStartMenu
    {
        #region  StartScreenController
        private static StarScreen.StartScreenController StartScreenController;
        public static void Load_StartScreenController(StarScreen.StartScreenController controller)
        {
            StartScreenController = controller;
        }
        public static void PlayButtonClicked()
        {
            StartScreenController.PlayButtonClicked();
        }

        public static void SettingsButtonClicked()
        {
            StartScreenController.SettingsButtonClicked();
        }

        #endregion

        #region LevelPacksController 
        private static int CurrentLevelPackIndex = 0;
        private static LevelPacksScreen.LevelPacksController LevelPacksController;
        public static void Load_LevelPacksController(LevelPacksScreen.LevelPacksController controller)
        {
            LevelPacksController = controller;
        }
        public static void LevelPackSelected(int index)
        {
            CurrentLevelPackIndex = index;
            LevelPacksController.LevelPackSelected(index);
        }
        public static int GetCurrentSelectedPack()
        {
            return CurrentLevelPackIndex;
        }
        #endregion

        #region  LevelsSelectController

        private static int CurrentLevelIndex = 0;
        private static LevelsScreen.LevelsSelectController LevelsSelectController;
        public static void Load_LevelsSelectController(LevelsScreen.LevelsSelectController controller)
        {
            LevelsSelectController = controller;
        }
        public static void LevelSelected(int index)
        {
            CurrentLevelIndex = index;
            LevelsSelectController.LevelSelected(index);
        }
        public static int GetCurrentSelectedLevel()
        {
            return CurrentLevelIndex;
        }
        #endregion

        public static void PlayButtonClickSFX()
        {
            
        }
    }

}
