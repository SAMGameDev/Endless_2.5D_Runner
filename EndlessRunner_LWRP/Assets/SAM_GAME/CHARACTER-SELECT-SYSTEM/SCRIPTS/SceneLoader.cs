using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndlessRunning
{
    internal enum Scenes
    {
        CharacterSelect,
        CharacterCustomize,
        GameScene,
        MainMenu,
    }
    public class SceneLoader : MonoBehaviour
    {
        public CharacterSelect GetSelectedCharacter;       
        public void LoadMenu()
        {
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
    }
}