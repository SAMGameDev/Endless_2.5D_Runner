﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndlessRunning
{
    public class PauseGame : MonoBehaviour
    {
        [SerializeField]
        private CharacterControl control;

        public static bool GameIsPaused = false;
        public GameObject PauseMenu;
        // Start is called before the first frame update
        void Start()
        {
            control = FindObjectOfType<CharacterControl>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }         
        }

        public void Resume()
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        public void Pause()
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        public void Restart()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}

