using UnityEngine;
using UnityEngine.SceneManagement;

namespace RunnerGame
{
    enum Scenes
    {
        CharacterSelect,
        MainScene,
    }
    public class StartGame : MonoBehaviour
    {
        public CharacterSelect GetSelectedCharacter;       
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (GetSelectedCharacter.SelectedCharacter != PlayableCharacterTypes.NONE)
                {
                    SceneManager.LoadScene(Scenes.MainScene.ToString());                  
                }
            }
        }
    }
}

