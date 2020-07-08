using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndlessRunning
{
    internal enum Scenes
    {
        CharacterSelect,
        GameScene,
        MainMenu,
    }
    public class SceneLoader : MonoBehaviour
    {
        public CharacterSelect GetSelectedCharacter;

        public void LoadGameScene()
        {
            if (GetSelectedCharacter.SelectedCharacter !=
                PlayableCharacterTypes.NONE)
            {
                GenralAudioManger.instance.SoundPlay("Click");
                SceneManager.LoadSceneAsync(Scenes.GameScene.ToString());
            }
        }
        public void LoadMenu()
        {
            SceneManager.LoadSceneAsync(Scenes.MainMenu.ToString());
        }
        public void LoadCharacterSelectScene()
        {
            SceneManager.LoadSceneAsync(Scenes.CharacterSelect.ToString());
        }
    }
}