using UnityEngine;
using UnityEngine.SceneManagement;

namespace RunnerGame
{
    enum Scenes
    {
        CharacterSelect,
        CharlotteCustomize,
        MainScene,
    }
    public class StartGame : MonoBehaviour
    {
        public CharacterSelect GetSelectedCharacter;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                LoadScene();
            }
        }
        public void LoadScene()
        {
            if (GetSelectedCharacter.SelectedCharacter !=
                PlayableCharacterTypes.NONE)
            {
                SceneManager.LoadScene(Scenes.MainScene.ToString());
            }
        }
    }
}

