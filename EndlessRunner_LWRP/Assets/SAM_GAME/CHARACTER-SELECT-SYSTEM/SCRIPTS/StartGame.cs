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
                GenralAudioManger.instance.SoundPlay("Click");
                SceneManager.LoadSceneAsync(Scenes.GameScene.ToString());
            }
        }
    }
}