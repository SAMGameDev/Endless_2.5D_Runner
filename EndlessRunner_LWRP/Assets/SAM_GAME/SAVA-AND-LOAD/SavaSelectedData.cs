using UnityEngine;

namespace EndlessRunning
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

