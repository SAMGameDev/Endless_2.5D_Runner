using UnityEngine;
using UnityEngine.SceneManagement;

namespace RunnerGame
{
    internal enum Scenes
    {
        CharacterSelect,
        CharlotteCustomize,
        MainScene,
    }

    public class StartGame : MonoBehaviour
    {
        public CharacterSelect GetSelectedCharacter;

        public void LoadScene()
        {
            AudioManger.instance.SoundPlay("Click");

            if (GetSelectedCharacter.SelectedCharacter !=
                PlayableCharacterTypes.NONE)
            {
                SceneManager.LoadScene(Scenes.MainScene.ToString());
            }
        }
    }
}