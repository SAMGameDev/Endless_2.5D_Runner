using UnityEngine;

namespace EndlessRunning
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