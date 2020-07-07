using UnityEngine;

namespace RunnerGame
{
    public class SavaSelectedData : MonoBehaviour
    {
        public GameSaveData data;
        private void OnDisable()
        {
            data.SaveSelectedCharacter();
        }
    }
}

