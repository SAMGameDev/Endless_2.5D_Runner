using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RunnerGame
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
            control = GameObject.FindObjectOfType<CharacterControl>();
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
            SceneManager.LoadScene("MyScene");
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}

