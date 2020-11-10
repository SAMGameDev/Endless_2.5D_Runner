using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndlessRunning
{
    public class PauseMenu : MonoBehaviour
    {
        private static bool GameIsPaused = false;
        [SerializeField] protected GameObject PauseMenu_gameobject;
        [SerializeField] protected CacheCharacterControl ControlCache;

        private void Update()
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

        public void Pause()
        {
            PauseMenu_gameobject.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            ControlCache.GetCharacterControl.isStarted = false;
        }

        public void Resume()
        {
            PauseMenu_gameobject.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
            ControlCache.GetCharacterControl.isStarted = true;
        }

        public void Restart()
        {
            SceneManager.LoadSceneAsync(Scenes.GameScene.ToString());
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}