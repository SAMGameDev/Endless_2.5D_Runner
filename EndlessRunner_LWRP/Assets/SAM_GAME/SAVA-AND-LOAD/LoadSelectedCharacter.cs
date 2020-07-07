using UnityEngine;

namespace RunnerGame
{
    public class LoadSelectedCharacter : MonoBehaviour
    {
        public GameSaveData saveData;
        private void Awake()
        {
            saveData.LoadSelectedCharacter();
        }
    }

}
