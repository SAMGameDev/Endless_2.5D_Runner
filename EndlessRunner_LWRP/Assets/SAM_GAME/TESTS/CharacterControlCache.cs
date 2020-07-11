using UnityEngine;

namespace EndlessRunning
{
    public class CharacterControlCache : MonoBehaviour
    {
        public CharacterControl characterControl;
        void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            characterControl = player.GetComponent<CharacterControl>();
        }
    }
}

