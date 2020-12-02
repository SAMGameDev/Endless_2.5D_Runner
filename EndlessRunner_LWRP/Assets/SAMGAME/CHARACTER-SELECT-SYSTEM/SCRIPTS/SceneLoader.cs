﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndlessRunning
{
    public enum Scenes
    {
        CharacterSelect,
        CharacterCustomize,
        GameScene,
        MainMenu,
    }

    public class SceneLoader : MonoBehaviour
    {
        public void LoadMenu()
        {
            if (Time.timeScale != 1f)
            {
                Time.timeScale = 1f;
            }
            SceneManager.LoadSceneAsync(Scenes.MainMenu.ToString());
        }

        public void LoadCharacterSelectScene()
        {
            SceneManager.LoadSceneAsync(Scenes.CharacterSelect.ToString());
        }

        public void LoadCharacterCustomize()
        {
            SceneManager.LoadSceneAsync(Scenes.CharacterCustomize.ToString());
        }

        public void LoadGameScene()
        {
            SceneManager.LoadSceneAsync(Scenes.GameScene.ToString());
        }
    }
}