using UnityEngine;
using UnityEngine.SceneManagement;

namespace RunnerGame
{
    internal enum Scenes
    {
        CharacterSelect,
        CharlotteCustomize,
        GameScene,
    }

    public class StartGame : MonoBehaviour
    {
        public CharacterSelect GetSelectedCharacter;

        public void LoadScene()
        {
            if (GetSelectedCharacter.SelectedCharacter !=
                PlayableCharacterTypes.NONE)
            {
                AudioManger.instance.SoundPlay("Click");
                SceneManager.LoadScene(Scenes.GameScene.ToString());
            }
        }
    }
}