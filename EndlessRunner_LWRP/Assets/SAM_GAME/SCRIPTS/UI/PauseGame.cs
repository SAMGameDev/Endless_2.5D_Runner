using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndlessRunning
{
    public class PauseGame : MonoBehaviour
    {
        public static bool GameIsPaused = false;
        public GameObject PauseMenu;

        [SerializeField] protected CharacterControlCache ControlCache;

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
        public void Pause()
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            ControlCache.GetCharacterControl.isStarted = false;
        }
        public void Resume()
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
            ControlCache.GetCharacterControl.isStarted = true;
        }
        public void Restart()
        {
            SceneManager.LoadScene(3);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
        public void QuitGame()
        {
            Application.Quit();
        }
        public void OnDisable()
        {
            if (Time.timeScale <= 0f)
            {
                Time.timeScale = 1f;
            }
        }
    }
}

