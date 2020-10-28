using UnityEngine;

namespace EndlessRunning
{
    public class CacheCharacterControl : MonoBehaviour
    {
        private CharacterControl characterControl;

        public CharacterControl GetCharacterControl
        {
            get
            {
                if (characterControl == null)
                {
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    characterControl = player.GetComponent<CharacterControl>();
                }
                return characterControl;
            }
        }
    }
}